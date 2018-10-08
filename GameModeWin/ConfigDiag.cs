using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;

namespace GameModeWin
{
    public class ConfigDiag
    {
        ///Disable notifications
        ///

        public void notifyOff()
        {
            RegistryKey servicePath = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\CurrentVersion", true);

            if (servicePath.OpenSubKey("PushNotifications") == null)
            {
                servicePath.Close();
                RegistryKey sp = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\CurrentVersion", true);
                sp = sp.CreateSubKey("PushNotifications");
                sp.Close();
                servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\CurrentVersion", true);
            }
            servicePath = servicePath.OpenSubKey("PushNotifications", true);

            servicePath.SetValue("NoTileApplicationNotification", 1);
            servicePath.SetValue("NoToastApplicationNotification", 1);
            servicePath.Close();


        }



        public void notifyOn()
        {
            RegistryKey servicePath = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true);
            if (servicePath.GetValue("NoToastApplicationNotification") != null)
            {
                servicePath.DeleteValue("NoToastApplicationNotification");
            }
            if (servicePath.GetValue("NoTileApplicationNotification") != null)
            {
                servicePath.DeleteValue("NoTileApplicationNotification");
            }
            servicePath.Close();



        }


        /// <summary>
        /// Application Compatibility
        /// </summary>



        public void appCompatOff()
        {
            RegistryKey servicePath3 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);

            if (servicePath3.OpenSubKey("AppCompat") == null)
            {
                servicePath3.Close();
                RegistryKey sp1 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);

                sp1 = sp1.CreateSubKey("AppCompat");
                sp1.Close();
                servicePath3 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
            }
            servicePath3 = servicePath3.OpenSubKey("AppCompat", true);

            servicePath3.SetValue("DisablePCA", 1);
            servicePath3.Close();
        }

        public void appCompatOn()
        {

            RegistryKey servicePath4 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\AppCompat", true);
            if (servicePath4.GetValue("DisablePCA") != null)
            {
                servicePath4.DeleteValue("DisablePCA");
            }
            servicePath4.Close();

        }


        /// <summary>
        /// Telemetry for diagnostic
        /// </summary>

        public void disableTelemtry()
        {
            RegistryKey servicePath3 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);

            if (servicePath3.OpenSubKey("DataCollection") == null)
            {
                servicePath3.Close();
                RegistryKey sp1 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);

                sp1 = sp1.CreateSubKey("DataCollection");
                sp1.Close();
                servicePath3 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
            }
            servicePath3 = servicePath3.OpenSubKey("DataCollection", true);

            /// they say that it will be equal to 1 if it's set to 0, but why they got 0?
            /// this can be commented and maybe the result will be the same
            /// but if it will be not set, then collected data will be set through settings manually
            /// disable this value here and commentout same deletevalue in notifyOn
            servicePath3.SetValue("AllowTelemetry", 0);
            servicePath3.Close();

        }



        public void telemetryOn()
        {


            RegistryKey servicePath3 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\DataCollection", true);
            if (servicePath3.GetValue("AllowTelemetry") != null)
            {
                servicePath3.SetValue("AllowTelemetry", 1);
            }
            servicePath3.Close();

            //remove datacollection settings, that can disable some feedback for windows

            RegistryKey servicePath4 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
            if (servicePath4.GetValue("DataCollection") != null)
            {
                servicePath4.SetValue("DataCollection", 2);
            }
            servicePath4.Close();


        }


        /// <summary>
        /// Disable DiagnosticTracking
        /// </summary>

        public void disDiag()
        {
            RegistryKey servicePath11 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\DiagTrack", true);

            servicePath11.SetValue("Start", 4);
            servicePath11.Close();

        }

        /// <summary>
        /// Enable Diag
        /// </summary>
        public void enDiag()
        {
            RegistryKey servicePath11 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\DiagTrack", true);

            servicePath11.SetValue("Start", 2);
            servicePath11.Close();

        }

        /// <summary>
        /// Start stop Telemetry Service
        /// schtasks.exe /Change /TN "Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser" /Disable
        /// </summary>
        /// 


        public void execStopTelemetry(bool exeComm)
        {
            String newEx = "Microsoft\\Windows\\Application Experience\\Microsoft Compatibility Appraiser";
            String exCom = "Disable";

            if (exeComm == false)
            {
                exCom = "Enable";
            }

            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "schtasks.exe ",
                    Arguments = "/Change /TN \"" + newEx + "\" /" + exCom + "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };


            proc.Start();

        }

        public void stopTelemetry()
        {
            execStopTelemetry(true);
        }

        public void startTelemetry()
        {
            execStopTelemetry(false);
        }



        /// <summary>
        /// Disable Indexng
        /// </summary>

        public void indxOff()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\WSearch", true);
            servicePath.SetValue("DelayedAutoStart", 0);
            servicePath.SetValue("Start", 4);
            servicePath.Close();


        }

        public void indxOn()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\WSearch", true);
            servicePath.SetValue("DelayedAutoStart", 1);
            servicePath.SetValue("Start", 2);
            servicePath.Close();


        }


        /// <summary>
        /// Cortana in windows Search
        /// </summary>

        public void enableCortana()
        {
            RegistryKey sp5 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true);
            if (sp5.GetValue("AllowCortana") != null)
            {
                sp5.DeleteValue("AllowCortana");
            }
            if (sp5.GetValue("DisableBackoff") != null)
            {
                sp5.DeleteValue("DisableBackoff");
            }

            sp5.Close();
        }



        public void disableCortana()
        {
            RegistryKey sp3 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
            if (sp3.OpenSubKey("Windows Search") == null)
            {

                RegistryKey sp4 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
                sp4.CreateSubKey("Windows Search", 0);
                sp4.Close();
            }
            sp3.Close();
            RegistryKey sp5 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true);

            sp5.SetValue("AllowCortana", 0);
            sp5.SetValue("DisableBackoff", 1);

            sp5.Close();
        }



        /// <summary>
        /// Clt .Net optimization
        /// </summary>

        public void clrOn()
        {

            RegistryKey sp = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\clr_optimization_v4.0.30319_32", true);
            sp.SetValue("DelayedAutostart", 1);
            sp.Close();

            RegistryKey sp1 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services", true);
            if (sp1.OpenSubKey("clr_optimization_v4.0.30319_64") != null)
            {
                sp1.Close();
                RegistryKey sp2 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\clr_optimization_v4.0.30319_64", true);
                sp2.SetValue("DelayedAutostart", 1);
                sp2.Close();
            }


        }

        public void clrOff()
        {


            RegistryKey sp = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\clr_optimization_v4.0.30319_32", true);
            sp.SetValue("DelayedAutostart", 0);
            sp.Close();

            RegistryKey sp1 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services", true);
            if (sp1.OpenSubKey("clr_optimization_v4.0.30319_64") != null)
            {
                sp1.Close();
                RegistryKey sp2 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\clr_optimization_v4.0.30319_64", true);
                sp2.SetValue("DelayedAutostart", 0);
                sp2.Close();
            }


        }


        /// <summary>
        /// Windows Search
        /// </summary>


        public void enableWSearch()
        {
            RegistryKey sp5 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true);

            if (sp5.GetValue("PreventIndexingCertainPaths") != null)
            {
                sp5.DeleteSubKey("PreventIndexingCertainPaths");
            }
            sp5.Close();
        }

        public void disableWsearch()
        {
            RegistryKey sp3 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
            if (sp3.OpenSubKey("Windows Search") == null)
            {

                RegistryKey sp4 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
                sp4.CreateSubKey("Windows Search", 0);
                sp4.Close();
            }
            sp3.Close();
            RegistryKey sp5 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true);

            if (sp5.OpenSubKey("PreventIndexingCertainPaths") == null)
            {
                RegistryKey sp6 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true);
                sp6.CreateSubKey("PreventIndexingCertainPaths", 0);
                sp6.Close();
            }
            sp5.Close();

            RegistryKey sp7 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search\\PreventIndexingCertainPaths", true);
            sp7.SetValue("C:\\", "C:\\");
            sp7.SetValue("D:\\", "D:\\");


        }




    }
}
