using Helicopter_Shooter_Game.GameObjects;

namespace Helicopter_Shooter_Game.Interfaces
{
    // OOP CONCEPT: INTERFACE
    internal interface ICollidable
    {
        void OnCollision(GameObject other);
    }
}