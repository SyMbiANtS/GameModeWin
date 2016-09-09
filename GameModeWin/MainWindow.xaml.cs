using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace GameModeWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bON_Click(object sender, RoutedEventArgs e)
        {
            setFetch();
            setTime();
        }

        private void bOFF_Click(object sender, RoutedEventArgs e)
        {
            unsetFetch();
            unsetTime();
        }

        private void createRegSettings()
        {


            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System", true);
            keySettings.OpenSubKey("GameConfigStore", true);
            if (keySettings.GetValue("GameMode") == null)
            {
                keySettings.CreateSubKey("GameMode");
            }
            keySettings.OpenSubKey("GameMode", true);


            if (keySettings.GetValue("Superfetch").Equals("1"))
            {
                cb101.IsChecked = true ;
                cb201.IsChecked = true;
            }
            
            if (keySettings.GetValue("udpCache").Equals("1"))
            {
                cb103.IsChecked = true;
                cb203.IsChecked = true;
            }

            if (keySettings.GetValue("tcpParam").Equals("1"))
            {
                cb104.IsChecked = true;
                cb204.IsChecked = true;
            }
            if (keySettings.GetValue("TimeBroker").Equals("1"))
            {
                cb107.IsChecked = true;
                cb207.IsChecked = true;
            }
           
        }

        private void writeRegSettings()
        {


            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System", true);
            keySettings.OpenSubKey("GameConfigStore", true);
            if (keySettings.GetValue("GameMode") == null)
            {
                keySettings.CreateSubKey("GameMode");
            }
            keySettings.OpenSubKey("GameMode", true);


            if (keySettings.GetValue("Superfetch").Equals("1"))
            {
                cb101.IsChecked = true;
                cb201.IsChecked = true;
            }

            if (keySettings.GetValue("udpCache").Equals("1"))
            {
                cb103.IsChecked = true;
                cb203.IsChecked = true;
            }

            if (keySettings.GetValue("tcpParam").Equals("1"))
            {
                cb104.IsChecked = true;
                cb204.IsChecked = true;
            }
            if (keySettings.GetValue("TimeBroker").Equals("1"))
            {
                cb107.IsChecked = true;
                cb207.IsChecked = true;
            }

        }


        /// <summary>
        /// Set Superfetch and Prefetch + Service
        /// </summary>

        public void setFetch()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("System", true);
            keyPath = keyPath.OpenSubKey("CurrentControlSet", true);
            keyPath = keyPath.OpenSubKey("Control", true);
            keyPath = keyPath.OpenSubKey("Session Manager", true);
            keyPath = keyPath.OpenSubKey("Memory Management", true);
            keyPath = keyPath.OpenSubKey("PrefetchParameters", true);
            
            keyPath.SetValue("EnablePrefetcher","0");
            keyPath.SetValue("EnableSuperfetch", "0");

            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System",true);
            servicePath = servicePath.OpenSubKey("CurrentControlSet", true);
            servicePath = servicePath.OpenSubKey("Services", true);
            servicePath = servicePath.OpenSubKey("SysMain", true);

            servicePath.SetValue("Start", "4");
            servicePath.Close();
            keyPath.Close();
        }

        public void unsetFetch()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("System" , true);
            keyPath = keyPath.OpenSubKey("CurrentControlSet", true);
            keyPath = keyPath.OpenSubKey("Control", true);
            keyPath = keyPath.OpenSubKey("Session Manager", true);
            keyPath = keyPath.OpenSubKey("Memory Management", true);
            keyPath = keyPath.OpenSubKey("PrefetchParameters", true);

            keyPath.SetValue("EnablePrefetcher", "3");
            keyPath.SetValue("EnableSuperfetch", "1");

            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System", true);
            servicePath = servicePath.OpenSubKey("CurrentControlSet", true);
            servicePath = servicePath.OpenSubKey("Services", true);
            servicePath = servicePath.OpenSubKey("SysMain", true);

            servicePath.SetValue("Start", "3");
            servicePath.Close();
            keyPath.Close();

        }


        /// <summary>
        /// Set TimeBroker
        /// </summary>

        public void setTime()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System", true);
            servicePath = servicePath.OpenSubKey("CurrentControlSet", true);
            servicePath = servicePath.OpenSubKey("Services", true);
            servicePath = servicePath.OpenSubKey("TimeBroker", true);

            servicePath.SetValue("Start", "4");
            servicePath.Close();
        }

        public void unsetTime()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System", true);
            servicePath = servicePath.OpenSubKey("CurrentControlSet", true);
            servicePath = servicePath.OpenSubKey("Services", true);
            servicePath = servicePath.OpenSubKey("TimeBroker", true);

            servicePath.SetValue("Start", "3");
            servicePath.Close();
        }


        /// <summary>
        /// Set Cache and UDP ??? defaults?
        /// </summary>

        public void setCacheUDP()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System", true);
            servicePath = servicePath.OpenSubKey("CurrentControlSet", true);
            servicePath = servicePath.OpenSubKey("Services", true);
            servicePath = servicePath.OpenSubKey("Dnscache", true);
            servicePath = servicePath.OpenSubKey("Parameters", true);

            
            servicePath.SetValue("NegativeCacheTime", "0");
            servicePath.SetValue("NegativeSOACacheTime", "0");
            servicePath.SetValue("NetFailureCacheTime", "0");
            servicePath.SetValue("MaximumUdpPacketSize", "512");

            servicePath.Close();
        }

        public void unsetCacheUDP()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System", true);
            servicePath = servicePath.OpenSubKey("CurrentControlSet", true);
            servicePath = servicePath.OpenSubKey("Services", true);
            servicePath = servicePath.OpenSubKey("Dnscache", true);
            servicePath = servicePath.OpenSubKey("Parameters", true);

            servicePath.SetValue("NegativeCacheTime", "600");
            servicePath.SetValue("NegativeSOACacheTime", "300");
            servicePath.SetValue("NetFailureCacheTime", "120");
            servicePath.SetValue("MaximumUdpPacketSize", "1472");

            servicePath.Close();
        }

        /// <summary>
        /// TcpNodelay enable
        /// </summary>

        public void setTCPNodelay()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("Software", true);
            keyPath = keyPath.OpenSubKey("Microsoft", true);
            keyPath = keyPath.OpenSubKey("Windows NT", true);
            keyPath = keyPath.OpenSubKey("CurrentVersion", true);
            keyPath = keyPath.OpenSubKey("Multimedia", true);
            keyPath = keyPath.OpenSubKey("SystemProfile", true);

            keyPath.SetValue("NetworkThrottlingIndex", "ffffffff");
            keyPath.SetValue("SystemResponsiveness", "0");
        }

        public void unsetTCPNodelay()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("Software", true);
            keyPath = keyPath.OpenSubKey("Microsoft", true);
            keyPath = keyPath.OpenSubKey("Windows NT", true);
            keyPath = keyPath.OpenSubKey("CurrentVersion", true);
            keyPath = keyPath.OpenSubKey("Multimedia", true);
            keyPath = keyPath.OpenSubKey("SystemProfile", true);

            keyPath.SetValue("NetworkThrottlingIndex", "10");
            keyPath.SetValue("SystemResponsiveness", "20");
        }


        ///disable firewall
        /// [HKLM\SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile]
        /// "EnableFirewall" = dword:00000000


        /// <summary>
        /// Site links mouse dbl click
        /// </summary>


        private void SymbLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://devel.symbiants.com");
        }

        private void SpeedLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.speedguide.net/downloads.php");
        }

        private void SteamLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://steamcommunity.com/groups/symbiants#announcements/detail/823418975648280408");
        }

        private void Steam2Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://steamcommunity.com/sharedfiles/filedetails/?id=476760198"); 
        }

        private void bReboot_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }
    }
}
