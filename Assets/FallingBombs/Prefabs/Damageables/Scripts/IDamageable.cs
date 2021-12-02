using System;

namespace FallingBombs.Damageables
{
    public interface IDamageable
    {
        public event Action<int> DamageTakenEvent;
        public event Action DeathEvent;
        public event Action<int> RespawnEvent;
        public int Health { get; }
        public string Id { get; }
        public void TakeDamage(object sender, int amount);
        public void Death();
        public void Respawn();
    }
}