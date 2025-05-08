using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ChampionSettingsClassLibrary;
using System.Diagnostics;
using System.Management;

namespace ChampionSettingsApp
{
    public partial class MainForm : Form
    {
        private int previousPrimary = 5, previousSecondary = 5;

        //primaryStyleId, subStyleId, selectedPerkIds[9], spell1Id, spell2Id
        public Dictionary<int, Tuple<int, int, int[], int, int>> settingsDict = new Dictionary<int, Tuple<int, int, int[], int, int>>();
        private string SAVE_FILE_PATH = Environment.ExpandEnvironmentVariables(@"%APPDATA%\Arbesu (^_^)\ChampionSettings\ChampionSettings.json");

        public MainForm()
        {
            InitializeComponent();

            LoadChampSettingsDict();
        }

        private void LoadChampSettingsDict()
        {
            if (File.Exists(SAVE_FILE_PATH))
            {
                using (StreamReader sr = new StreamReader(SAVE_FILE_PATH))
                {
                    var fileContent = sr.ReadToEnd();
                    settingsDict = JsonConvert.DeserializeObject<Dictionary<int, Tuple<int, int, int[], int, int>>>(fileContent);
                };
            }
        }

        private void comboBoxPrimaryPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxPrimaryPath.SelectedIndex;
            if (previousPrimary != index)
            {
                previousPrimary = index;
                ClearPrimaryRunes();
                switch (index)
                {
                    case 0:
                        comboBoxPrimaryKeyStone.Items.AddRange(Runes.Precision.keyStone);
                        comboBoxPrimary1.Items.AddRange(Runes.Precision.slot1);
                        comboBoxPrimary2.Items.AddRange(Runes.Precision.slot2);
                        comboBoxPrimary3.Items.AddRange(Runes.Precision.slot3);
                        break;
                    case 1:
                        comboBoxPrimaryKeyStone.Items.AddRange(Runes.Dominance.keyStone);
                        comboBoxPrimary1.Items.AddRange(Runes.Dominance.slot1);
                        comboBoxPrimary2.Items.AddRange(Runes.Dominance.slot2);
                        comboBoxPrimary3.Items.AddRange(Runes.Dominance.slot3);
                        break;
                    case 2:
                        comboBoxPrimaryKeyStone.Items.AddRange(Runes.Sorcery.keyStone);
                        comboBoxPrimary1.Items.AddRange(Runes.Sorcery.slot1);
                        comboBoxPrimary2.Items.AddRange(Runes.Sorcery.slot2);
                        comboBoxPrimary3.Items.AddRange(Runes.Sorcery.slot3);
                        break;
                    case 3:
                        comboBoxPrimaryKeyStone.Items.AddRange(Runes.Resolve.keyStone);
                        comboBoxPrimary1.Items.AddRange(Runes.Resolve.slot1);
                        comboBoxPrimary2.Items.AddRange(Runes.Resolve.slot2);
                        comboBoxPrimary3.Items.AddRange(Runes.Resolve.slot3);
                        break;
                    case 4:
                        comboBoxPrimaryKeyStone.Items.AddRange(Runes.Inspiration.keyStone);
                        comboBoxPrimary1.Items.AddRange(Runes.Inspiration.slot1);
                        comboBoxPrimary2.Items.AddRange(Runes.Inspiration.slot2);
                        comboBoxPrimary3.Items.AddRange(Runes.Inspiration.slot3);
                        break;
                }

                if (comboBoxSecondaryPath.SelectedIndex == index)
                {
                    ClearSecondaryRunes();
                    comboBoxSecondaryPath.SelectedIndex = -1;
                }
            }
        }

        private void ClearPrimaryRunes()
        {
            comboBoxPrimaryKeyStone.Items.Clear();
            comboBoxPrimary1.Items.Clear();
            comboBoxPrimary2.Items.Clear();
            comboBoxPrimary3.Items.Clear();
        }

        private void comboBoxSecondaryPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxSecondaryPath.SelectedIndex;
            if (previousSecondary != index)
            {
                previousSecondary = index;
                ClearSecondaryRunes();
                switch (index)
                {
                    case 0:
                        comboBoxSecondary1.Items.AddRange(Runes.Precision.slot1);
                        comboBoxSecondary1.Items.AddRange(Runes.Precision.slot2);
                        comboBoxSecondary1.Items.AddRange(Runes.Precision.slot3);
                        comboBoxSecondary2.Items.AddRange(Runes.Precision.slot1);
                        comboBoxSecondary2.Items.AddRange(Runes.Precision.slot2);
                        comboBoxSecondary2.Items.AddRange(Runes.Precision.slot3);
                        break;
                    case 1:
                        comboBoxSecondary1.Items.AddRange(Runes.Dominance.slot1);
                        comboBoxSecondary1.Items.AddRange(Runes.Dominance.slot2);
                        comboBoxSecondary1.Items.AddRange(Runes.Dominance.slot3);
                        comboBoxSecondary2.Items.AddRange(Runes.Dominance.slot1);
                        comboBoxSecondary2.Items.AddRange(Runes.Dominance.slot2);
                        comboBoxSecondary2.Items.AddRange(Runes.Dominance.slot3);
                        break;
                    case 2:
                        comboBoxSecondary1.Items.AddRange(Runes.Sorcery.slot1);
                        comboBoxSecondary1.Items.AddRange(Runes.Sorcery.slot2);
                        comboBoxSecondary1.Items.AddRange(Runes.Sorcery.slot3);
                        comboBoxSecondary2.Items.AddRange(Runes.Sorcery.slot1);
                        comboBoxSecondary2.Items.AddRange(Runes.Sorcery.slot2);
                        comboBoxSecondary2.Items.AddRange(Runes.Sorcery.slot3);
                        break;
                    case 3:
                        comboBoxSecondary1.Items.AddRange(Runes.Resolve.slot1);
                        comboBoxSecondary1.Items.AddRange(Runes.Resolve.slot2);
                        comboBoxSecondary1.Items.AddRange(Runes.Resolve.slot3);
                        comboBoxSecondary2.Items.AddRange(Runes.Resolve.slot1);
                        comboBoxSecondary2.Items.AddRange(Runes.Resolve.slot2);
                        comboBoxSecondary2.Items.AddRange(Runes.Resolve.slot3);
                        break;
                    case 4:
                        comboBoxSecondary1.Items.AddRange(Runes.Inspiration.slot1);
                        comboBoxSecondary1.Items.AddRange(Runes.Inspiration.slot2);
                        comboBoxSecondary1.Items.AddRange(Runes.Inspiration.slot3);
                        comboBoxSecondary2.Items.AddRange(Runes.Inspiration.slot1);
                        comboBoxSecondary2.Items.AddRange(Runes.Inspiration.slot2);
                        comboBoxSecondary2.Items.AddRange(Runes.Inspiration.slot3);
                        break;
                }

                if (comboBoxPrimaryPath.SelectedIndex == index)
                {
                    ClearPrimaryRunes();
                    comboBoxPrimaryPath.SelectedIndex = -1;
                }
            }
        }

        private void ClearSecondaryRunes()
        {
            comboBoxSecondary1.Items.Clear();
            comboBoxSecondary2.Items.Clear();
        }

        private void comboBoxSecondary1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSecondary1.SelectedIndex >= 0 && comboBoxSecondary2.SelectedIndex >= 0 && (comboBoxSecondary1.SelectedIndex / 3 == comboBoxSecondary2.SelectedIndex / 3 || (comboBoxSecondary1.SelectedIndex > 5 && comboBoxSecondary2.SelectedIndex > 5 && comboBoxSecondaryPath.SelectedIndex == 1)))
            {
                comboBoxSecondary2.SelectedIndex = -1;
            }
        }

        private void comboBoxSecondary2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSecondary1.SelectedIndex >= 0 && comboBoxSecondary2.SelectedIndex >= 0 && (comboBoxSecondary1.SelectedIndex / 3 == comboBoxSecondary2.SelectedIndex / 3 || (comboBoxSecondary1.SelectedIndex > 5 && comboBoxSecondary2.SelectedIndex > 5 && comboBoxSecondaryPath.SelectedIndex == 1)))
            {
                comboBoxSecondary1.SelectedIndex = -1;
            }
        }

        private void comboBoxSpell1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSpell1.SelectedIndex == comboBoxSpell2.SelectedIndex)
            {
                comboBoxSpell2.SelectedIndex = -1;
            }
        }

        private void comboBoxSpell2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSpell1.SelectedIndex == comboBoxSpell2.SelectedIndex)
            {
                comboBoxSpell1.SelectedIndex = -1;
            }
        }

        private void comboBoxChampion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChampion.SelectedIndex == -1) return;

            int champId = IdDictionaries.champDict[(string)comboBoxChampion.SelectedItem];

            if (settingsDict.ContainsKey(champId))
            {
                comboBoxPrimaryPath.SelectedIndex = comboBoxPrimaryPath.Items.IndexOf(IdDictionaries.styleDict.First(x => x.Value == settingsDict[champId].Item1).Key);
                comboBoxSecondaryPath.SelectedIndex = comboBoxSecondaryPath.Items.IndexOf(IdDictionaries.styleDict.First(x => x.Value == settingsDict[champId].Item2).Key);
                comboBoxPrimaryKeyStone.SelectedIndex = comboBoxPrimaryKeyStone.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[0]).Key);
                comboBoxPrimary1.SelectedIndex = comboBoxPrimary1.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[1]).Key);
                comboBoxPrimary2.SelectedIndex = comboBoxPrimary2.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[2]).Key);
                comboBoxPrimary3.SelectedIndex = comboBoxPrimary3.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[3]).Key);
                comboBoxSecondary1.SelectedIndex = comboBoxSecondary1.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[4]).Key);
                comboBoxSecondary2.SelectedIndex = comboBoxSecondary2.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[5]).Key);
                comboBoxOffensive.SelectedIndex = comboBoxOffensive.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[6]).Key);
                comboBoxFlex.SelectedIndex = comboBoxFlex.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[7]).Key);
                comboBoxDefensive.SelectedIndex = comboBoxDefensive.Items.IndexOf(IdDictionaries.perkDict.First(x => x.Value == settingsDict[champId].Item3[8]).Key);
                comboBoxSpell1.SelectedIndex = comboBoxSpell1.Items.IndexOf(IdDictionaries.spellDict.First(x => x.Value == settingsDict[champId].Item4).Key);
                comboBoxSpell2.SelectedIndex = comboBoxSpell2.Items.IndexOf(IdDictionaries.spellDict.First(x => x.Value == settingsDict[champId].Item5).Key);
            }
            else
            {
                ComboBox[] cmbArray = new ComboBox[]
                {
                    comboBoxPrimaryPath, comboBoxPrimaryKeyStone, comboBoxPrimary1, comboBoxPrimary2, comboBoxPrimary3,
                    comboBoxSecondaryPath, comboBoxSecondary1, comboBoxSecondary2, comboBoxOffensive, comboBoxFlex,
                    comboBoxDefensive, comboBoxSpell1, comboBoxSpell2
                };
                foreach(ComboBox cb in cmbArray)
                {
                    cb.SelectedIndex = -1;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //check every comboBox is filled
            bool isEmpty = false;
            ComboBox[] cmbArray = new ComboBox[]
            {
                comboBoxChampion, comboBoxPrimaryPath, comboBoxPrimaryKeyStone, comboBoxPrimary1, comboBoxPrimary2,
                comboBoxPrimary3, comboBoxSecondaryPath, comboBoxSecondary1, comboBoxSecondary2, comboBoxOffensive,
                comboBoxFlex, comboBoxDefensive, comboBoxSpell1, comboBoxSpell2
            };
            foreach(ComboBox cb in cmbArray)
            {
                if (cb.SelectedIndex == -1)
                {
                    isEmpty = true;
                    break;
                }
            }
            if (!isEmpty)
            {
                int champ = IdDictionaries.champDict[(string)comboBoxChampion.SelectedItem];
                int[] perks = new int[9]
                {
                IdDictionaries.perkDict[(string)comboBoxPrimaryKeyStone.SelectedItem],
                IdDictionaries.perkDict[(string)comboBoxPrimary1.SelectedItem],
                IdDictionaries.perkDict[(string)comboBoxPrimary2.SelectedItem],
                IdDictionaries.perkDict[(string)comboBoxPrimary3.SelectedItem],
                IdDictionaries.perkDict[(string)comboBoxSecondary1.SelectedItem],
                IdDictionaries.perkDict[(string)comboBoxSecondary2.SelectedItem],
                IdDictionaries.perkDict[(string)comboBoxOffensive.SelectedItem],
                IdDictionaries.perkDict[(string)comboBoxFlex.SelectedItem],
                IdDictionaries.perkDict[(string)comboBoxDefensive.SelectedItem]
                };

                //change or add champ to dict
                if (settingsDict.ContainsKey(champ))
                {
                    settingsDict[champ] = new Tuple<int, int, int[], int, int>(
                        IdDictionaries.styleDict[(string)comboBoxPrimaryPath.SelectedItem],
                        IdDictionaries.styleDict[(string)comboBoxSecondaryPath.SelectedItem], 
                        perks,
                        IdDictionaries.spellDict[(string)comboBoxSpell1.SelectedItem],
                        IdDictionaries.spellDict[(string)comboBoxSpell2.SelectedItem]);
                }
                else
                {
                    settingsDict.Add(champ, new Tuple<int, int, int[], int, int>(
                        IdDictionaries.styleDict[(string)comboBoxPrimaryPath.SelectedItem], 
                        IdDictionaries.styleDict[(string)comboBoxSecondaryPath.SelectedItem], 
                        perks,
                        IdDictionaries.spellDict[(string)comboBoxSpell1.SelectedItem],
                        IdDictionaries.spellDict[(string)comboBoxSpell2.SelectedItem]));
                }

                //save dict in a file
                var jsonChampDictionary = JsonConvert.SerializeObject(settingsDict);
                using (StreamWriter sw = new StreamWriter(SAVE_FILE_PATH, false))
                {
                    sw.Write(jsonChampDictionary);
                };

                MessageBox.Show($"{(string)comboBoxChampion.SelectedItem}'s settings have been saved", "Champion Settings Saved", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please fill all the settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
