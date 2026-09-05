using System.Drawing;

namespace Helicopter_Shooter_Game.GameObjects
{
    // OOP CONCEPT: INHERITANCE
    // FastUFO inherits ALL UFO behavior and only overrides Update()
    internal class FastUFO : UFO
    {
        public FastUFO(Image img, int x, int y) : base(img, x, y, ufoSpeed: 18) { }

        // OOP CONCEPT: POLYMORPHISM (method overriding)
        // Same method name "Update", completely different behavior than base UFO
        private int zigzagDir = 1;
        private int zigzagTimer = 0;

        public override void Update()
        {
            X -= speed;

            // Zigzag movement unique to FastUFO
            zigzagTimer++;
            if (zigzagTimer >= 10)
            {
                Y += zigzagDir * 8;
                zigzagDir *= -1;
                zigzagTimer = 0;
            }

            if (X + Sprite.Width < 0)
                Respawn(1000, 500);
        }
    }
}