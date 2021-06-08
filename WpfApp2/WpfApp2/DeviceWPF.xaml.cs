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
    /// Логика взаимодействия для DeviceWPF.xaml
    /// </summary>
    public partial class DeviceWPF : Window
    {
        Device deviceWP;
        List<Sensor> sensors;
        public DeviceWPF(Device device)
        {
            InitializeComponent();

            QuantitiesType[] type = (QuantitiesType[])Enum.GetValues(typeof(QuantitiesType));
            foreach (QuantitiesType stype in type)
            {
                SensorCombobox.Items.Add(stype.ToString());
            }
            deviceWP = device;
            sensors = Sensor.ReadSensorList("sensors");
            sensors.ForEach(a =>
            {
                DeviceCombobox.Items.Add(a.ToString());
            });
            if (deviceWP != null && deviceWP.Sensor != null)
            {
                DeviceCombobox.SelectedIndex = DeviceCombobox.Items.IndexOf(device.Sensor.ToString());
                TextBox.Text = deviceWP.Numb.ToString();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int selectIndex = DeviceCombobox.SelectedIndex;
            if (selectIndex<0||selectIndex>=sensors.Count)
            {
                MessageBox.Show("Need to choose");
                return;
            }
            sensorWPF sensorModal = new sensorWPF(sensors[selectIndex]);
            if (sensorModal.ShowDialog() == true)
            {
                DeviceCombobox.Items[selectIndex] = sensors[selectIndex].ToString();
                Sensor.WriteSensorToFile("Sensors", sensors);
            }
            else 
            {
                MessageBox.Show("Changes are not saved");
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Sensor newSendor = new Sensor();
            sensorWPF woodModal = new sensorWPF(newSendor);
            if (woodModal.ShowDialog() == true)
            {
                DeviceCombobox.Items.Add(newSendor.ToString());
                sensors.Add(newSendor);
                Sensor.WriteSensorToFile("Sensors", sensors);
            }
            else
            {
                MessageBox.Show("Changes are not saved");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = DeviceCombobox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= sensors.Count)
            {
                MessageBox.Show("You need to choose author!");
                return;
            }
            if (TextBox.Text == "")
            {
                MessageBox.Show("Need to feel the field");
                return;
            }

            deviceWP.Sensor = sensors[selectedIndex];
            deviceWP.Numb = int.Parse(TextBox.Text);
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
