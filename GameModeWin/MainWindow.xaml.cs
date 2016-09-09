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
        public ConfigRegistryClass crc = new ConfigRegistryClass();
        public ConfigServices csrv = new ConfigServices();

        public MainWindow()
        {
            InitializeComponent();
            createRegSettings();
        }

        private void bON_Click(object sender, RoutedEventArgs e)
        {
            
            crc.setFetch();
            csrv.setTime();
            writeRegSettings();
        }

        private void bOFF_Click(object sender, RoutedEventArgs e)
        {
            crc.unsetFetch();
            csrv.unsetTime();
            writeRegSettings();

        }





        public void createRegSettings()
        {


            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore", true);
            if (keySettings.GetValue("GameMode") == null)
            {
                keySettings.CreateSubKey("GameMode");
                
                keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\GameMode", true);
               
                keySettings.SetValue("Superfetch", 1);
                keySettings.SetValue("udpCache", 1);
                keySettings.SetValue("tcpParam", 1);
                keySettings.SetValue("TimeBroker", "1");

            }
            keySettings.Close();
            keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\GameMode", true);

            if (keySettings.GetValue("Superfetch").Equals("0"))
            {
                cb101.IsChecked = false;
                cb201.IsChecked = false;
            }

            if (keySettings.GetValue("udpCache").Equals("0"))
            {
                cb103.IsChecked = false;
                cb203.IsChecked = false;
            }

            if (keySettings.GetValue("tcpParam").Equals("0"))
            {
                cb104.IsChecked = false;
                cb204.IsChecked = false;
            }
            if (keySettings.GetValue("TimeBroker").Equals("0"))
            {
                cb107.IsChecked = false;
                cb207.IsChecked = false;
            }

        }

        private void writeRegSettings()
        {


            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\GameMode", true);
            

            if (cb101.IsChecked == true)
            {
                keySettings.SetValue("Superfetch", 1);
            }  else   {
                keySettings.SetValue("Superfetch", 0);
            }


            if (cb103.IsChecked == true)
            {
                keySettings.SetValue("udpCache", "1");
            }  else   {
                keySettings.SetValue("udpCache", "0");
            }


            if (cb104.IsChecked == true)
            {
                keySettings.SetValue("tcpParam", "1");
            }  else   {
                keySettings.SetValue("tcpParam", "0");
            }


            if (cb107.IsChecked == true)
            {
                keySettings.SetValue("TimeBroker", "1");
            }  else   {
                keySettings.SetValue("TimeBroker", "0");
            }


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
