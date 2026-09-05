using System;
using System.Windows.Forms;
using Helicopter_Shooter_Game.Game;

namespace Helicopter_Shooter_Game
{
    public partial class Form1 : Form
    {
        // OOP CONCEPT: ENCAPSULATION — input flags are private
        private bool goUp = false;
        private bool goDown = false;

        // OOP CONCEPT: COMPOSITION — Form1 HAS-A GameManager
        private GameManager gameManager;

        private bool levelTransitioning = false;
        private bool gameEnded = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            gameEnded = false;
            levelTransitioning = false;

            // Clean up any old controls if restarting
            if (gameManager != null)
                gameManager.RemoveAllControls();

            // OOP CONCEPT: OBJECT CREATION — creating a GameManager instance
            gameManager = new GameManager(this);

            // OOP CONCEPT: EVENTS/DELEGATION — subscribe to game events
            gameManager.OnGameOver += HandleGameOver;
            gameManager.OnLevelComplete += HandleLevelComplete;

            gameManager.StartLevel1();
            GameTimer.Start();
        }

        // ---- Timer Tick: main game loop ----
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameEnded || levelTransitioning) return;

            // OOP CONCEPT: POLYMORPHISM — gameManager.Update calls each
            // object's own Update() method through the GameObject base type
            gameManager.Update(goUp, goDown);
        }

        // ---- Keyboard Input ----
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) goUp = true;
            if (e.KeyCode == Keys.Down) goDown = true;

            if (e.KeyCode == Keys.Space)
                gameManager?.PlayerFire();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) goUp = false;
            if (e.KeyCode == Keys.Down) goDown = false;
        }

        // ---- Game Events ----
        private void HandleGameOver()
        {
            if (gameEnded) return;
            gameEnded = true;
            GameTimer.Stop();

            // Show game over screen
            frmGameEnd endScreen = new frmGameEnd(
                gameManager.FinalScore,
                gameManager.FinalLevel,
                isWin: false
            );

            DialogResult result = endScreen.ShowDialog();
            if (result == DialogResult.Yes)
                StartNewGame();
            else
                this.Close();
        }

        private void HandleLevelComplete()
        {
            if (levelTransitioning) return;
            levelTransitioning = true;
            GameTimer.Stop();

            MessageBox.Show(
                "Level 1 Complete!\nScore: " + gameManager.FinalScore +
                "\n\nGet ready for Level 2!\nUFOs now fire back!",
                "Level Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Transition to Level 2
            gameManager.StartLevel2();
            levelTransitioning = false;
            GameTimer.Start();
        }

        private void HandleWin()
        {
            if (gameEnded) return;
            gameEnded = true;
            GameTimer.Stop();

            frmGameEnd winScreen = new frmGameEnd(
                gameManager.FinalScore,
                gameManager.FinalLevel,
                isWin: true
            );

            DialogResult result = winScreen.ShowDialog();
            if (result == DialogResult.Yes)
                StartNewGame();
            else
                this.Close();
        }
    }
}
