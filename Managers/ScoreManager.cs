using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helicopter_Shooter_Game.Managers
{
    internal class ScoreManager
    {
        private int score = 0;

        // Read-only from outside
        public int Score
        {
            get { return score; }
        }

        public void AddPoints(int points)
        {
            score += points;
        }

        public void Reset()
        {
            score = 0;
        }
    }
}

