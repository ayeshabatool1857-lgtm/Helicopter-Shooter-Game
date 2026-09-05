using System;
using System.Drawing;
using System.Windows.Forms;

namespace Helicopter_Shooter_Game
{
    // =====================================================
    // OOP CONCEPT: CLASS (concrete form class)
    // frmStart is a Form — it inherits from System.Windows.Forms.Form
    // =====================================================
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            // Background is set in designer
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 gameForm = new Form1();
            gameForm.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
