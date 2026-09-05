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
    internal class Pillar : GameObject, ICollidable
    {
        // OOP CONCEPT: ENCAPSULATION — speed is private, managed internally
        private int speed;

        public Pillar(Image img, int x, int y, int scrollSpeed)
        {
            speed = scrollSpeed;

            Sprite = new PictureBox();
            Sprite.Image = img;
            Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            Sprite.Width = 58;
            Sprite.Height = 186;
            Sprite.BackColor = Color.Transparent;
            X = x;
            Y = y;
            Sprite.Tag = "pillar";
        }

        // OOP CONCEPT: ABSTRACTION (implementing abstract Update)
        public override void Update()
        {
            X -= speed;

            // Loop pillar back to right side when it goes off screen
            if (X < -200)
                X = 1000;
        }

        public void SetSpeed(int newSpeed)
        {
            speed = newSpeed;
        }

        // OOP CONCEPT: INTERFACE IMPLEMENTATION
        // Pillar does nothing on collision — the Player/GameManager handles game-over
        public void OnCollision(GameObject other)
        {
            // Pillar is static obstacle — no special reaction needed
        }
    }
}
