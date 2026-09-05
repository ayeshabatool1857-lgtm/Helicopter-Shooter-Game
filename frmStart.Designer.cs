namespace Helicopter_Shooter_Game
{
    partial class frmStart
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Impact", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Yellow;
            this.lblTitle.Text = "HELICOPTER SHOOTER";
            this.lblTitle.Location = new System.Drawing.Point(160, 100);

            // btnPlay
            this.btnPlay.Text = "PLAY";
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnPlay.BackColor = System.Drawing.Color.Green;
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Size = new System.Drawing.Size(180, 55);
            this.btnPlay.Location = new System.Drawing.Point(270, 230);
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);

            // btnExit
            this.btnExit.Text = "EXIT";
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.BackColor = System.Drawing.Color.DarkRed;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Size = new System.Drawing.Size(180, 55);
            this.btnExit.Location = new System.Drawing.Point(270, 310);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // frmStart
            this.ClientSize = new System.Drawing.Size(719, 461);
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Helicopter Shooter - Start";
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnExit);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;
    }
}
