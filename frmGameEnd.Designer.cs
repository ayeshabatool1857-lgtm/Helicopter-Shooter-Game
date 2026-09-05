namespace Helicopter_Shooter_Game
{
    partial class frmGameEnd
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Impact", 32F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(200, 80);
            this.lblTitle.Text = "GAME OVER";

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(250, 180);
            this.lblScore.Text = "Final Score: 0";

            // lblLevel
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblLevel.ForeColor = System.Drawing.Color.White;
            this.lblLevel.Location = new System.Drawing.Point(270, 220);
            this.lblLevel.Text = "Level Reached: 1";

            // btnRestart
            this.btnRestart.Text = "PLAY AGAIN";
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.btnRestart.BackColor = System.Drawing.Color.Green;
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Size = new System.Drawing.Size(160, 50);
            this.btnRestart.Location = new System.Drawing.Point(200, 300);
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);

            // btnExit
            this.btnExit.Text = "EXIT";
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.btnExit.BackColor = System.Drawing.Color.DarkRed;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Size = new System.Drawing.Size(160, 50);
            this.btnExit.Location = new System.Drawing.Point(390, 300);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // frmGameEnd
            this.ClientSize = new System.Drawing.Size(719, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Game Over";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnExit);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Label lblScore;
        internal System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnExit;
    }
}
