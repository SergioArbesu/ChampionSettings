using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace ChampionSettingsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(serviceInstaller1.ServiceName))
            {
                sc.Start();
            }

            string filePath = Environment.ExpandEnvironmentVariables(@"C:\Users\belen\AppData\Roaming\Arbesu (^_^)\ChampionSettings\ChampionSettings.json");

            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}