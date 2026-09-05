using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helicopter_Shooter_Game.GameObjects
{
    internal abstract class GameObject
    {
        // OOP CONCEPT: ENCAPSULATION
        // Properties expose data through controlled getters/setters
        public PictureBox Sprite { get; set; }
        public bool IsAlive { get; set; } = true;

        public int X
        {
            get { return Sprite.Left; }
            set { Sprite.Left = value; }
        }

        public int Y
        {
            get { return Sprite.Top; }
            set { Sprite.Top = value; }
        }

        // OOP CONCEPT: ABSTRACTION
        // Declared here but has no body — subclasses MUST provide their own update logic
        public abstract void Update();

        public Rectangle Bounds
        {
            get { return Sprite.Bounds; }
        }

        // OOP CONCEPT: POLYMORPHISM (virtual method)
        // Base destroy sets IsAlive=false and hides sprite.
        // Subclasses can override if they need extra cleanup.
        public virtual void Destroy()
        {
            IsAlive = false;
            Sprite.Hide();
        }
    }
}
