using Lab_4;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_4_Wpf
{
    /// <summary>
    /// Логика взаимодействия для ChannelWPF.xaml
    /// </summary>
    public partial class ChannelWPF : Window
    {
        public Channel channelWP;
        private Device newDevice;

        public ChannelWPF(Channel channel)
        {
            InitializeComponent();
            channelWP = channel;
            channelWP.Count = channel.Count;
            if (channelWP != null && channelWP.Devices != null)
            {
                if (channel.Devices != null)
                {
                    channel.Devices.ForEach(lumber =>
                    {
                        List.Items.Add(lumber);
                    });
                }
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Device newDevice = new Device();
            DeviceWPF lumberModal = new DeviceWPF(newDevice);
            if (lumberModal.ShowDialog() == true)
            {
                channelWP.AddDevice(newDevice);
                List.Items.Add(newDevice.ToString());
            }
            else
            {
                MessageBox.Show("Changes are not saved");
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = List.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= channelWP.Devices.Count)
            {
                MessageBox.Show("Choose!");
                return;
            }
            DeviceWPF lumberModal = new DeviceWPF(channelWP.Devices[selectedIndex]);
            if (lumberModal.ShowDialog() == true)
            {
                List.Items[selectedIndex] = channelWP.Devices[selectedIndex].ToString();
            }
            else
            {
                MessageBox.Show("Changes was not saved");
            }
        }

        private void Cancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void exit_Save_Click_1(object sender, RoutedEventArgs e)
        {
            channelWP.Count = List.Items.Count;
            if (List.Items == null)
            {
                MessageBox.Show("Need to feel fields!");
                return;
            }
            DialogResult = true;
            this.Close();
        }
    }
}
