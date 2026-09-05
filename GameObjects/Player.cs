using Helicopter_Shooter_Game.Enums;
using Helicopter_Shooter_Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helicopter_Shooter_Game.GameObjects
{
    internal class Player : GameObject, ICollidable
    {
        // OOP CONCEPT: ENCAPSULATION
        // Private fields exposed through public properties
        private int speed = 7;
        private bool canShoot = true;

        public bool CanShoot
        {
            get { return canShoot; }
            set { canShoot = value; }
        }

        public Player(Image img, int x, int y)
        {
            Sprite = new PictureBox();
            Sprite.Image = img;
            Sprite.SizeMode = PictureBoxSizeMode.AutoSize;
            Sprite.BackColor = Color.Transparent;
            X = x;
            Y = y;
            Sprite.Tag = "player";
        }

        // OOP CONCEPT: ABSTRACTION (implementing abstract Update)
        public override void Update()
        {
            // Player is moved by keyboard input in the game loop, not here
        }

        public void MoveUp(int formHeight)
        {
            if (Y > 0)
                Y -= speed;
        }

        public void MoveDown(int formHeight)
        {
            if (Y + Sprite.Height < formHeight)
                Y += speed;
        }

        public Bullet Fire()
        {
            // Fire a bullet from the front of the helicopter
            Bullet b = new Bullet(X + Sprite.Width, Y + Sprite.Height / 2 - 3, BulletDirection.Right);
            return b;
        }

        // OOP CONCEPT: INTERFACE IMPLEMENTATION
        // Player defines its own specific collision response
        public void OnCollision(GameObject other)
        {
            // Player colliding with UFO or Pillar ends the game
            // Handled by GameManager — Destroy() called from there
            Destroy();
        }
    }
}
