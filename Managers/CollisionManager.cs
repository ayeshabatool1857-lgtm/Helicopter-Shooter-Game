using Helicopter_Shooter_Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helicopter_Shooter_Game.Managers
{
    internal class CollisionManager
    {
        public void CheckCollisions(List<GameObject> objects, Player player)
        {
            foreach (GameObject obj in objects)
            {
                if (!obj.IsAlive) continue;

                // Check if player collides with UFO or Pillar
                if (obj is UFO || obj is Pillar)
                {
                    if (player.IsAlive && player.Bounds.IntersectsWith(obj.Bounds))
                    {
                        player.OnCollision(obj);  // Player handles game-over logic via interface
                        return;
                    }
                }

                // Check if player bullet hits a UFO
                if (obj is Bullet bullet && bullet.Direction == Enums.BulletDirection.Right)
                {
                    foreach (GameObject target in objects)
                    {
                        if (target is UFO ufo && ufo.IsAlive)
                        {
                            if (bullet.Bounds.IntersectsWith(ufo.Bounds))
                            {
                                ufo.OnCollision(bullet); // UFO destroys itself via interface
                                bullet.Destroy();
                                break;
                            }
                        }
                    }
                }

                // Check if enemy bullet hits player (Level 2)
                if (obj is Bullet enemyBullet && enemyBullet.Direction == Enums.BulletDirection.Left)
                {
                    if (player.IsAlive && player.Bounds.IntersectsWith(enemyBullet.Bounds))
                    {
                        player.OnCollision(enemyBullet);
                        enemyBullet.Destroy();
                    }
                }
            }
        }
    }
}
