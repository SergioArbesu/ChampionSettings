using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using PoniLCU;
using static PoniLCU.LeagueClient;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ChampionSettingsClassLibrary;
using System.Security.Cryptography;

namespace ChampionSettingsService
{
    public partial class ChampionSettingsService : ServiceBase
    {
        private string SAVE_FILE_PATH = null;
        private LeagueClient client = new LeagueClient(credentials.cmd);

        //primaryStyleId, subStyleId, selectedPerkIds[9], spell1Id, spell2Id
        private Dictionary<int, Tuple<int, int, int[], int, int>> settingsDict = new Dictionary<int, Tuple<int, int, int[], int, int>>();

        private int lastId = -1;

        public ChampionSettingsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                SAVE_FILE_PATH = Environment.ExpandEnvironmentVariables(@"C:\Users\belen\AppData\Roaming\Arbesu (^_^)\ChampionSettings\ChampionSettings.json");
                client = new LeagueClient(credentials.cmd);
                if (client.IsConnected) OnLeagueConnected();
                client.OnConnected += OnLeagueConnected;
                client.OnDisconnected += OnLeagueDisconnected;
            }
            catch(Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(Environment.ExpandEnvironmentVariables(@"C:\Users\belen\AppData\Roaming\Arbesu (^_^)\ChampionSettings\ServiceErrorLog.txt"), false))
                {
                    string stringToWrite = ex.ToString() + $"\nSAVE_FILE_PATH: {SAVE_FILE_PATH}\nsettingsDict: {settingsDict}" +
                        $"\nlastId: {lastId}\nclient: {client}";
                    sw.WriteLine(stringToWrite);
                }
            }
        }

        protected override void OnStop()
        {
        }

        private void OnLeagueConnected()
        {
            client.Subscribe("/lol-champ-select/v1/current-champion", OnChampionPicked);
            client.Subscribe("/lol-gameflow/v1/gameflow-phase", OnGameflowPhase);
        }

        private void OnLeagueDisconnected()
        {
            client.ClearAllListeners();
        }

        private void OnChampionPicked(OnWebsocketEventArgs e)
        {
            if (File.Exists(SAVE_FILE_PATH))
            {
                using (StreamReader sr = new StreamReader(SAVE_FILE_PATH))
                {
                    string fileContent = sr.ReadToEnd();
                    settingsDict = JsonConvert.DeserializeObject<Dictionary<int, Tuple<int, int, int[], int, int>>>(fileContent);
                    WriteLog(fileContent);
                };
            }

            if (e == null) return;
            if (e.Data == null) return;

            int champId = (int)e.Data;
            if (lastId != champId)
            {
                if (settingsDict.ContainsKey(champId))
                {
                    var spellsData = new
                    {
                        spell1Id = settingsDict[champId].Item4,
                        spell2Id = settingsDict[champId].Item5
                    };
                    string body1 = JsonConvert.SerializeObject(spellsData);
                    client.Request(requestMethod.PATCH, "/lol-champ-select/v1/session/my-selection", body1);

                    string currentPage = client.Request(requestMethod.GET, "/lol-perks/v1/currentpage").Result;
                    int idCurrentPage = (int)JObject.Parse(currentPage)["id"];
                    client.Request(requestMethod.DELETE, $"/lol-perks/v1/pages/{idCurrentPage}");
                    var runesData = new
                    {
                        name = $"Champion Settings Rune Page: {IdDictionaries.champDict.First(x => x.Value.Equals(champId)).Key}",
                        primaryStyleId = settingsDict[champId].Item1,
                        subStyleId = settingsDict[champId].Item2,
                        selectedPerkIds = settingsDict[champId].Item3,
                        current = true
                    };
                    string body2 = JsonConvert.SerializeObject(runesData);
                    client.Request(requestMethod.POST, "/lol-perks/v1/pages", body2);
                }
                lastId = champId;
            }
        }

        void OnGameflowPhase(OnWebsocketEventArgs e)
        {
            if (e == null) return;
            if (e.Data == null) return;

            if ((string)e.Data == "ChampSelect") lastId = -1;
        }

        void WriteLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\belen\AppData\Roaming\Arbesu (^_^)\ChampionSettings\ServiceErrorLog.txt", false))
            {
                sw.WriteLine(message);
            }
        }
    }
} 
