using Helicopter_Shooter_Game.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helicopter_Shooter_Game.GameObjects
{
    internal class Bullet : GameObject
    {
        // OOP CONCEPT: ENCAPSULATION
        // Direction is read-only from outside; only set in constructor
        public BulletDirection Direction { get; private set; }

        private int speed = 20;

        public Bullet(int x, int y, BulletDirection dir)
        {
            Direction = dir;

            Sprite = new PictureBox();
            Sprite.BackColor = dir == BulletDirection.Right ? Color.Maroon : Color.OrangeRed;
            Sprite.Width = 14;
            Sprite.Height = 6;
            Sprite.Left = x;
            Sprite.Top = y;
            Sprite.Tag = "bullet";
        }

        // OOP CONCEPT: ABSTRACTION (implementing the abstract method)
        // Each concrete class provides its own update logic
        public override void Update()
        {
            if (Direction == BulletDirection.Right)
                X += speed;
            else
                X -= speed;
        }
    }
}
