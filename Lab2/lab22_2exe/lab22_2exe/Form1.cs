using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab22_2exe
{
    public partial class Form1 : Form
    {
        delegate void Del(object sender, EventArgs e);

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Gray;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Opacity < 1f)
            {
                this.Opacity = 1;
            }
            else 
            {
                this.Opacity = 0.4;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Gray)
            {
                this.BackColor = Color.Red;
            }
            else
            {
                this.BackColor = Color.Gray;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Я супермегакнопка,\nі цього мене не позбавиш!");
            Del[] but = new Del[] { button1_Click, button2_Click, button3_Click };
            if (checkBox1.Checked == true)
            {
                but[0](sender, e);
            }
            if (checkBox2.Checked == true)
            {
                but[1](sender, e);
            }
            if (checkBox3.Checked == true)
            {
                but[2](sender, e);
            }
        }
    }
}
