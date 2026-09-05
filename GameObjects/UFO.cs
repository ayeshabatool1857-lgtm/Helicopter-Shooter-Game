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
    internal class UFO : GameObject, ICollidable
    {
        // OOP CONCEPT: ENCAPSULATION — private fields with public access
        protected int speed;
        protected Random rand = new Random();

        // Tracks whether this UFO has already been counted for score
        public bool Scored { get; set; } = false;

        // UFO can fire bullets in Level 2
        public int FireTimer { get; set; } = 0;

        public UFO(Image img, int x, int y, int ufoSpeed)
        {
            speed = ufoSpeed;

            Sprite = new PictureBox();
            Sprite.Image = img;
            Sprite.SizeMode = PictureBoxSizeMode.AutoSize;
            Sprite.BackColor = Color.Transparent;
            X = x;
            Y = y;
            Sprite.Tag = "ufo";
        }

        // OOP CONCEPT: ABSTRACTION (implementing abstract Update)
        // OOP CONCEPT: POLYMORPHISM (virtual — can be overridden by FastUFO)
        public override void Update()
        {
            X -= speed;

            // When UFO exits left side, reset to right side at new random height
            if (X + Sprite.Width < 0)
                Respawn(1000, 500);
        }

        public void Respawn(int formWidth, int formHeight)
        {
            X = formWidth;
            Y = rand.Next(30, formHeight - Sprite.Height - 10);
        }

        // Fires a bullet toward the player (used in Level 2)
        public Bullet FireBullet()
        {
            Bullet b = new Bullet(X, Y + Sprite.Height / 2 - 3, BulletDirection.Left);
            return b;
        }

        // OOP CONCEPT: INTERFACE IMPLEMENTATION
        public void OnCollision(GameObject other)
        {
            // UFO destroyed when hit by player bullet
            if (other is Bullet b && b.Direction == BulletDirection.Right)
            {
                Destroy();
            }
        }
    }
}
