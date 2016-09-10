using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace GameModeWin
{
    public class ConfigServices
    {
        /// <summary>
        /// Set TimeBroker
        /// </summary>

        public void setTime()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\TimeBrokerSvc", true);

            servicePath.SetValue("Start", 4);
            servicePath.Close();
        }

        public void unsetTime()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\TimeBrokerSvc", true);

            servicePath.SetValue("Start", 3);
            servicePath.Close();
        }

        /// <summary>
        /// Disable Windows Defender
        /// </summary>

        public void defenderOff()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender", true);

            servicePath.SetValue("DisableAntiSpyware", 1);
            servicePath.Close();
        }

        public void defenderOn()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender", true);

            servicePath.DeleteValue("DisableAntiSpyware");
            servicePath.Close();
        }


        /// <summary>
        /// Local Override for Windows Defender
        /// </summary>

        public void defLocalOverON()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", true);
            
            servicePath.SetValue("LocalSettingOverrideDisableBehaviorMonitoring", 1);
            servicePath.SetValue("LocalSettingOverrideDisableOnAccessProtection", 1);
            servicePath.SetValue("LocalSettingOverrideDisableRealtimeMonitoring", 1);
            servicePath.SetValue("LocalSettingOverrideRealtimeScanDirection", 1);
            servicePath.Close();
        }

        public void defLocalOverOFF()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", true);
        
            servicePath.DeleteValue("LocalSettingOverrideDisableBehaviorMonitoring");
            servicePath.DeleteValue("LocalSettingOverrideDisableOnAccessProtection");
            servicePath.DeleteValue("LocalSettingOverrideDisableRealtimeMonitoring");
            servicePath.DeleteValue("LocalSettingOverrideRealtimeScanDirection");
            servicePath.Close();
        }

        /// <summary>
        /// Disable AutoUpdate
        /// </summary>

        public void updateOff()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);

            if (servicePath.OpenSubKey("WindowsUpdate") == null)
            {
                servicePath.Close();
                RegistryKey sp = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
                sp = sp.CreateSubKey("WindowsUpdate");
                
                sp.Close();

                RegistryKey sp2 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\WindowsUpdate", true);
                    if (sp2.OpenSubKey("AU") == null)
                    {
                        sp2.CreateSubKey("AU");
                    sp2.Close();
                }
                servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
            }

            RegistryKey sp3 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\WindowsUpdate", true);
            if (sp3.OpenSubKey("AU") == null)
            {
                sp3.CreateSubKey("AU");
                sp3.Close();
            }

            servicePath = servicePath.OpenSubKey("WindowsUpdate\\AU", true);

            servicePath.SetValue("NoAutoUpdate", 1);
            servicePath.Close();
        }

        public void updateOn()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU", true);

            servicePath.DeleteValue("NoAutoUpdate");
            servicePath.Close();
        }

        /// <summary>
        /// Disable Windows Store AutoUpdate
        /// </summary>

        public void updateStoreOff()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft", true);
            
            if (servicePath.OpenSubKey("WindowsStore") == null)
            {
                servicePath.Close();
                RegistryKey sp = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft", true);
                sp = sp.CreateSubKey("WindowsStore");
                sp.Close();
                servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft", true);
            }

            servicePath = servicePath.OpenSubKey("WindowsStore", true);
            servicePath.SetValue("AutoDownload", 2);
            servicePath.Close();
        }

        public void updateStoreOn()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\WindowsStore", true);

            servicePath.DeleteValue("AutoDownload");
            servicePath.Close();
        }

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

            RegistryKey servicePath1 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\DiagTrack", true);

            servicePath1.SetValue("Start", 4);
            servicePath1.Close();

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
            servicePath3.SetValue("AllowTelemetry", 0);
            servicePath3.Close();
              
        }

        public void notifyOn()
        {
            RegistryKey servicePath = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true);

            servicePath.DeleteValue("NoToastApplicationNotification");
            servicePath.DeleteValue("NoTileApplicationNotification");
            servicePath.Close();

            RegistryKey servicePath1 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\DiagTrack", true);

            servicePath1.SetValue("Start", 2);
            servicePath1.Close();

            RegistryKey servicePath3 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\DataCollection", true);
            servicePath3.DeleteValue("AllowTelemetry");
            servicePath3.Close();

        }

        /// <summary>
        /// Disable Indexng, telemetry, clr-opt
        /// </summary>

        public void indxOff()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\WSearch", true);
            servicePath.SetValue("DelayedAutoStart", 0);
            servicePath.SetValue("Start", 4);
            servicePath.Close();

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

        public void indxOn()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\WSearch", true);
            servicePath.SetValue("DelayedAutoStart", 1);
            servicePath.SetValue("Start", 2);
            servicePath.Close();

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


    }
}
