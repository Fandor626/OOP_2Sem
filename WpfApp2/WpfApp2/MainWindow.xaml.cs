using Lab_4;
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

namespace Lab_4_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Channel> channels = new List<Channel>();
        public MainWindow()
        {
            InitializeComponent();
            channels = Channel.ReadChannelList("channels");
            channels.ForEach(channel =>
            {
                ListBox.Items.Add(channel.ToShortStr());
            });
        }
 
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Save?", "Message", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Channel.WriteChannelsToFile("Channels", channels);
            }
        }
        private void Create_Click_1(object sender, RoutedEventArgs e)
        {
            Channel newChannel = new Channel();
            ChannelWPF channelModel = new ChannelWPF(newChannel);
            if (channelModel.ShowDialog() == true)
            {
                newChannel.Count = ListBox.Items.Count + 1;
                ListBox.Items.Add(newChannel.ToShortStr());
                channels.Add(newChannel);
            }
            else
            {
                MessageBox.Show("Changes are not saved");
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = ListBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= channels.Count)
            {
                MessageBox.Show("Choose");
                return;
            }
            ChannelWPF channelModal = new ChannelWPF(channels[ListBox.SelectedIndex]);
            bool? result = channelModal.ShowDialog();
            if (result == true)
            {
                ListBox.Items[selectedIndex] = channels[ListBox.SelectedIndex].ToShortStr();
            }
            else
            {
                MessageBox.Show("Changes are not saved");
            }
        }

        private void Show_details_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = ListBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= channels.Count)
            {
                MessageBox.Show("Choose");
            }
            else
            {
                MessageBox.Show(channels[selectedIndex].ToString());
            }
        }

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedIndex = ListBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= channels.Count)
            {
                MessageBox.Show("Choose!");
                return;
            }
            channels.RemoveAt(selectedIndex);
            ListBox.Items.RemoveAt(selectedIndex);
        }
    }
}
