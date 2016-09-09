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
                RegistryKey sp = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft", true);
                sp = sp.OpenSubKey("Windows\\CurrentVersion", true);
                sp = sp.CreateSubKey("PushNotifications");
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

            servicePath.DeleteValue("NoToastApplicationNotification");
            servicePath.DeleteValue("NoTileApplicationNotification");
            servicePath.Close();
        }

        /// <summary>
        /// Disable Indexng
        /// </summary>

        public void indxOff()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\WSearch", true);

            servicePath.SetValue("Start", 4);
            servicePath.Close();
        }

        public void indxOn()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\WSearch", true);

            servicePath.SetValue("Start", 2);
            servicePath.Close();
        }


    }
}
