﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NextForm_Click(object sender, EventArgs e)
        {
            Form2 form2 =new Form2();
            form2.ShowDialog();

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
