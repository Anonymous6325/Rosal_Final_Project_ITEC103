﻿using ITEC_103_ROSAL___MAKASAYAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITEC_103_ROSAL___MAKASAYAN
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Create an instance of Form1
            Sub_Menu subMenu = new Sub_Menu();

            // Show Form1 and hide the Menu form
            subMenu.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        
    }
}
