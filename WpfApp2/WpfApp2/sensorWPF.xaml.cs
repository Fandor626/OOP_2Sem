using Lab_4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для sensorWPF.xaml
    /// </summary>
    public partial class sensorWPF : Window
    {
        Sensor sensorWP;
        public sensorWPF()
        {
            InitializeComponent();
        }

        public sensorWPF(Sensor sensor)
        {
            InitializeComponent();

            sensorWP = sensor;

            if (sensor!=null&&sensor.Type!=null)
            {
                TypeText.Text = sensor.Type;
                RangeText.Text = Convert.ToString(sensor.Range);
                CurentText.Text = Convert.ToString(sensor.CuretValue);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (TypeText.Text == "" || RangeText.Text == "" || CurentText.Text == "")
            {
                MessageBox.Show("Need to feel fields!");
                return;
            }
            sensorWP.Type = TypeText.Text;
            sensorWP.Range = Convert.ToInt16(RangeText.Text);
            sensorWP.CuretValue = Convert.ToInt16(CurentText.Text);
            DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сохранить изменения?", "Сообщение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes && TypeText.Text != "" && RangeText.Text != "" && CurentText.Text != "")
            {
                sensorWP.Type = TypeText.Text;
                sensorWP.Range = Convert.ToInt16(RangeText.Text);
                sensorWP.CuretValue = Convert.ToInt16(CurentText.Text);
                DialogResult = true;
            }
            else
            {

                this.Close();
            }

        }
    }
}
