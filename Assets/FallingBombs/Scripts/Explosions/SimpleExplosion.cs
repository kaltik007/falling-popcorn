using FallingBombs.Prefabs.Characters;
using FallingBombs.Prefabs.Characters.Views;
using UnityEngine;

namespace FallingBombs.Scripts.Explosions
{
    public class SimpleExplosion : IExplosion
    {
        private float _explosionRadius;
        private int _explosionDamage;
        
        public SimpleExplosion(ExplosionInfo explosionInfo)
        {
            _explosionRadius = explosionInfo.Radius;
            _explosionDamage = explosionInfo.Damage;
        }

        public void DealDamage(Vector3 detonationPoint)
        {
            Collider[] colliders = Physics.OverlapSphere(detonationPoint, _explosionRadius);
            foreach (Collider collider in colliders)
            {
                var damageableView = collider.GetComponent<DamageableViewBase>();
                if (damageableView != null)
                {
                    damageableView.DetectDamage(this, _explosionDamage);
                }
            }
        }
    }
}