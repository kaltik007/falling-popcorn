using UnityEngine;

namespace FallingBombs.Explosions
{
    public interface IExplosion
    {
        public void DealDamage(Vector3 detonationPoint);
    }
}