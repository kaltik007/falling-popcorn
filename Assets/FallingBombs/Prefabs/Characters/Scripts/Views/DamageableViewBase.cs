using System;
using UnityEngine;

namespace FallingBombs.Prefabs.Characters.Views
{
    public abstract class DamageableViewBase : MonoBehaviour, IDamageableView
    {
        private DamageableBehaviour _damageableBehaviour;

        public virtual void SetDamageableBehaviour(DamageableBehaviour damageableMono)
        {
            if (damageableMono == null)
                throw new NullReferenceException($"DamageableBehaviour reference is missing!");
            
            _damageableBehaviour = damageableMono;
        }

        public virtual void DetectDamage(object sender, int damage)
        {
            _damageableBehaviour?.TakeDamage(sender, damage);
        }
        public abstract void OnRespawn(string id, int respawnHealth);

        public abstract void OnDamageTaken(string id, int amount);

        public abstract void OnDeath(string id);
    }
}