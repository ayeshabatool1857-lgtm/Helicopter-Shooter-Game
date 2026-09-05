using System;
using System.Windows.Forms;

namespace Helicopter_Shooter_Game
{
    // =====================================================
    // OOP CONCEPT: ENCAPSULATION + CLASS
    // frmGameEnd takes score, level, and a win/lose flag
    // in its constructor. The form only shows what it needs.
    // =====================================================
    public partial class frmGameEnd : Form
    {
        public frmGameEnd(int score, int level, bool isWin)
        {
            InitializeComponent();

            if (isWin)
            {
                lblTitle.Text = "YOU WIN!";
                lblTitle.ForeColor = System.Drawing.Color.Gold;
                this.BackColor = System.Drawing.Color.DarkGreen;
            }
            else
            {
                lblTitle.Text = "GAME OVER";
                lblTitle.ForeColor = System.Drawing.Color.OrangeRed;
                this.BackColor = System.Drawing.Color.DarkRed;
            }

            lblScore.Text = "Final Score: " + score;
            lblLevel.Text = "Level Reached: " + level;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
