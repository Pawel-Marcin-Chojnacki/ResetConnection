using ROOT.CIMV2.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
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

namespace ResetConnection
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

        public static ProcessStartInfo pInfo = new ProcessStartInfo();
        public static Process p;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectQuery query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=2");
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            uint c = 100;
            for (int i = 1; i <= 12; i++)
            {
                query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=" + i.ToString());
                search = new ManagementObjectSearcher(query);
                foreach (ManagementObject result in search.Get())
                {
                    NetworkAdapter adapter = new NetworkAdapter(result);

                    // Identify the adapter you wish to disable here. 
                    // In particular, check the AdapterType and 
                    // Description properties.

                    // Here, we're selecting the LAN adapters.
                    //if (adapter.AdapterType.Equals("Ethernet 802.3"))
                    //{
                    //    adapter.Enable();
                    //}
                    MessageBox.Show(adapter.AdapterType.ToString() + ":  " + adapter.Name.ToString());
                    if (adapter.NetConnectionStatus == 2)
                    {
                        c = adapter.Disable();
                    }
                    MessageBox.Show(adapter.NetConnectionStatus.ToString() + " " + c.ToString());
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SelectQuery query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=2");
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
                
            for (int i = 1; i <= 12; i++)
            {
                query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus="+i.ToString());
                search = new ManagementObjectSearcher(query);
                foreach (ManagementObject result in search.Get())
                {
                    NetworkAdapter adapter = new NetworkAdapter(result);

                    // Identify the adapter you wish to disable here. 
                    // In particular, check the AdapterType and 
                    // Description properties.

                    // Here, we're selecting the LAN adapters.
                    //if (adapter.AdapterType.Equals("Ethernet 802.3"))
                    //{
                    //    adapter.Enable();
                    //}
                    if (adapter.AdapterType.Equals("Wireless"))
                    {
                        adapter.Enable();
                    }
                }
            }
        }
    }
}
