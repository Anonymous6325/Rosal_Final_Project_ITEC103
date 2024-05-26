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
    public partial class Mind_Testcs : Form
    {
        public Mind_Testcs()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Easy easyForm = new Easy();

            // Show the Difficult form
            easyForm.Show();

            // Close the current form
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Moderate moderateForm = new Moderate();

            // Show the Difficult form
            moderateForm.Show();

            // Close the current form
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Difficult difficultForm = new Difficult();

            // Show the Difficult form
            difficultForm.Show();

            // Close the current form
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Create an instance of Form1
            Sub_Menu subMenu = new Sub_Menu();

            // Show Form1 and hide the Menu form
            subMenu.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
