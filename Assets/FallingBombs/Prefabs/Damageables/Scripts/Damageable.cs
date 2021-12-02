using System;

namespace FallingBombs.Damageables
{
    public class Damageable : IDamageable
    {
        public event Action<int> DamageTakenEvent;
        public event Action DeathEvent;
        public event Action<int> RespawnEvent;

        private int _maxHealth;
        private int _currentHealth;
        private string _id;
        
        public int Health => _currentHealth;
        public string Id => _id;

        public Damageable(DamageableInfo info)
        {
            _maxHealth = info.Health;
            _id = info.Id;
        }

        public void TakeDamage(object sender, int amount)
        {
            if (_currentHealth <= amount)
            {
                Death();
            }
            else
            {
                _currentHealth -= amount;
                DamageTakenEvent?.Invoke(amount);
            }
        }

        public void Death()
        {
            DeathEvent?.Invoke();
        }

        public void Respawn()
        {
            _currentHealth = _maxHealth;
            RespawnEvent?.Invoke(_maxHealth);
        }
    }
}