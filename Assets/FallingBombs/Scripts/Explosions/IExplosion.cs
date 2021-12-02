using UnityEngine;

namespace FallingBombs.Scripts.Explosions
{
    public interface IExplosion
    {
        public void DealDamage(Vector3 detonationPoint);
    }
}