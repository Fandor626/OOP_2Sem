using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorna4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(FigureType.Circle);
            comboBox1.Items.Add(FigureType.Square);
            comboBox1.Items.Add(FigureType.Rhomb);
            Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = b;
        }
        public enum FigureType { Circle,Square,Rhomb}
        FigureType figure { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            figure = (FigureType)comboBox1.SelectedItem;
            Figure f;
            switch (figure)
            {
                case FigureType.Circle:
                    double radius = Convert.ToDouble(textBox1.Text);
                    f = new Circle(20, 200, radius);

                    Task task = new Task(() =>
                    {
                        while (true)
                        {
                            if (f.x >=1000)
                            {
                                
                                break;
                            }
                            f.MoveRight(pictureBox1);                          
                            Thread.Sleep(100);
                            this.Invoke(new MethodInvoker(delegate {
                                pictureBox1.Refresh();
                            }));
                        }
                    });
                    task.Start();
    

                    break;
                case FigureType.Square:
                    double sideLength = Convert.ToDouble(textBox2.Text);
                    f = new Square(20, 200, (int)sideLength);
                    Task task2 = new Task(() =>
                    {
                        while (true)
                        {
                            if (f.x >= 1000)
                            {

                                break;
                            }
                            f.MoveRight(pictureBox1);
                            Thread.Sleep(100);
                            this.Invoke(new MethodInvoker(delegate {
                                pictureBox1.Refresh();
                            }));
                        }
                    });
                    task2.Start();
                    break;
                case FigureType.Rhomb:
                    double horizontal = Convert.ToDouble(textBox3.Text);
                    double vertical = Convert.ToDouble(textBox4.Text);
                    f = new Rhomb(20, 200, horizontal,vertical);
                    Task task3 = new Task(() =>
                    {
                        while (true)
                        {
                            if (f.x >= 1000)
                            {

                                break;
                            }
                            f.MoveRight(pictureBox1);
                            Thread.Sleep(100);
                            this.Invoke(new MethodInvoker(delegate {
                                pictureBox1.Refresh();
                            }));
                        }
                    });
                    task3.Start();
                    break;
            }
        }
    }
}
