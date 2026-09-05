using Helicopter_Shooter_Game.GameObjects;
using Helicopter_Shooter_Game.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helicopter_Shooter_Game.Game
{
    internal class GameManager
    {
        // --- Private fields (ENCAPSULATION) ---
        private Form form;
        private Player player;
        private List<GameObject> gameObjects;
        private ScoreManager scoreManager;
        private CollisionManager collisionManager;
        private Random rand = new Random();

        private int level = 1;
        private int pillarSpeed = 8;
        private int ufoSpeed = 10;
        private int enemyFireTimer = 0;
        private bool shootKeyDown = false;

        // Labels shown on form
        private Label lblScore;
        private Label lblLevel;

        // UFO images cycling (alien1, alien2, alien3)
        private int ufoImageIndex = 0;

        // Events — Form1 subscribes to know when game ends
        public event Action OnGameOver;
        public event Action OnLevelComplete;

        // Properties for end-screen
        public int FinalScore => scoreManager.Score;
        public int FinalLevel => level;

        public GameManager(Form f)
        {
            form = f;
            gameObjects = new List<GameObject>();
            scoreManager = new ScoreManager();
            collisionManager = new CollisionManager();
        }

        // ---- Setup ----

        public void StartLevel1()
        {
            level = 1;
            pillarSpeed = 4;
            ufoSpeed = 5;
            scoreManager.Reset();
            gameObjects.Clear();

            CreatePlayer();
            CreatePillars();
            CreateUFO();
            CreateHUD();
        }

        public void StartLevel2()
        {
            level = 2;
            pillarSpeed = 6;
            ufoSpeed = 9;

            // Remove old objects from form
            foreach (var go in gameObjects)
                form.Controls.Remove(go.Sprite);
            gameObjects.Clear();

            // Recreate with higher difficulty
            CreatePlayer();
            CreatePillars();

            // Level 2 has TWO UFOs — one normal, one fast (Polymorphism)
            CreateUFO();
            CreateFastUFO();

            UpdateHUD();
        }

        private void CreatePlayer()
        {
            player = new Player(Properties.Resources.Halicopter, 61, 78);
            gameObjects.Add(player);
            form.Controls.Add(player.Sprite);
            player.Sprite.BringToFront();
        }

        private void CreatePillars()
        {
            // OOP CONCEPT: OBJECTS — each Pillar is an instance of the Pillar class
            Pillar p1 = new Pillar(Properties.Resources.pillar, 567, -27, pillarSpeed);
            Pillar p2 = new Pillar(Properties.Resources.pillar, 229, 239, pillarSpeed);
            gameObjects.Add(p1);
            gameObjects.Add(p2);
            form.Controls.Add(p1.Sprite);
            form.Controls.Add(p2.Sprite);
        }

        private void CreateUFO()
        {
            // OOP CONCEPT: POLYMORPHISM — UFO stored as base type GameObject
            UFO ufo = new UFO(GetNextUFOImage(), 855, 220, ufoSpeed);
            gameObjects.Add(ufo);
            form.Controls.Add(ufo.Sprite);
        }

        private void CreateFastUFO()
        {
            // OOP CONCEPT: POLYMORPHISM — FastUFO is stored as GameObject in same list
            FastUFO fast = new FastUFO((System.Drawing.Image)Properties.Resources.alien2, 700, 100);
            gameObjects.Add(fast);
            form.Controls.Add(fast.Sprite);
        }

        private void CreateHUD()
        {
            lblScore = new Label();
            lblScore.Text = "Score: 0";
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            lblScore.Location = new Point(12, 9);
            lblScore.AutoSize = true;
            form.Controls.Add(lblScore);
            lblScore.BringToFront();

            lblLevel = new Label();
            lblLevel.Text = "Level: 1";
            lblLevel.ForeColor = Color.Yellow;
            lblLevel.BackColor = Color.Transparent;
            lblLevel.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            lblLevel.Location = new Point(form.ClientSize.Width / 2 - 40, 9);
            lblLevel.AutoSize = true;
            form.Controls.Add(lblLevel);
            lblLevel.BringToFront();
        }

        private void UpdateHUD()
        {
            if (lblScore != null) lblScore.BringToFront();
            if (lblLevel != null)
            {
                lblLevel.Text = "Level: " + level;
                lblLevel.BringToFront();
            }
        }

        // ---- Main Update Loop ----

        public void Update(bool goUp, bool goDown)
        {
            if (!player.IsAlive)
            {
                OnGameOver?.Invoke();
                return;
            }

            // Move player
            if (goUp) player.MoveUp(form.ClientSize.Height);
            if (goDown) player.MoveDown(form.ClientSize.Height);

            // Update all game objects (POLYMORPHISM: each calls its own Update())
            foreach (GameObject go in gameObjects)
            {
                if (go.IsAlive)
                    go.Update();  // UFO.Update(), FastUFO.Update(), Pillar.Update(), Bullet.Update()
            }

            // Level 2: UFOs fire back at player
            if (level == 2)
                HandleEnemyFire();

            // Check collisions
            collisionManager.CheckCollisions(gameObjects, player);

            // Clean up bullets that left the screen
            RemoveOffscreenBullets();

            // Update score for destroyed UFOs
            UpdateScore();

            // Update HUD
            if (lblScore != null)
                lblScore.Text = "Score: " + scoreManager.Score;

            // Check level transition (score threshold)
            if (level == 1 && scoreManager.Score >= 10)
            {
                OnLevelComplete?.Invoke();
            }
        }

        public void PlayerFire()
        {
            Bullet b = player.Fire();
            gameObjects.Add(b);
            form.Controls.Add(b.Sprite);
            b.Sprite.BringToFront();
        }

        // ---- Private Helpers ----

        private void HandleEnemyFire()
        {
            enemyFireTimer++;
            if (enemyFireTimer >= 40)
            {
                enemyFireTimer = 0;
                foreach (GameObject go in gameObjects)
                {
                    if (go is UFO ufo && ufo.IsAlive)
                    {
                        Bullet b = ufo.FireBullet();
                        gameObjects.Add(b);
                        form.Controls.Add(b.Sprite);
                    }
                }
            }
        }

        private void RemoveOffscreenBullets()
        {
            for (int i = gameObjects.Count - 1; i >= 0; i--)
            {
                if (gameObjects[i] is Bullet bullet)
                {
                    if (bullet.X > form.ClientSize.Width + 50 ||
                        bullet.X < -50 ||
                        !bullet.IsAlive)
                    {
                        form.Controls.Remove(bullet.Sprite);
                        gameObjects.RemoveAt(i);
                    }
                }
            }
        }

        private void UpdateScore()
        {
            foreach (GameObject go in gameObjects)
            {
                if (go is UFO ufo && !ufo.IsAlive && !ufo.Scored)
                {
                    scoreManager.AddPoints(1);
                    ufo.Scored = true;

                    // Respawn UFO at right side after short delay
                    RespawnUFO(ufo);
                }
            }
        }

        private void RespawnUFO(UFO ufo)
        {
            ufo.IsAlive = true;
            ufo.Scored = false;
            ufo.Sprite.Show();
            ufo.Sprite.Image = GetNextUFOImage();
            ufo.Respawn(form.ClientSize.Width, form.ClientSize.Height);
        }

        private Image GetNextUFOImage()
        {
            ufoImageIndex++;
            if (ufoImageIndex > 3) ufoImageIndex = 1;
            switch (ufoImageIndex)
            {
                case 1: return Properties.Resources.alien1;
                case 2: return Properties.Resources.alien2;
                default: return Properties.Resources.alien3;
            }
        }

        public void RemoveAllControls()
        {
            foreach (var go in gameObjects)
                form.Controls.Remove(go.Sprite);
            if (lblScore != null) form.Controls.Remove(lblScore);
            if (lblLevel != null) form.Controls.Remove(lblLevel);
        }
    }
}

