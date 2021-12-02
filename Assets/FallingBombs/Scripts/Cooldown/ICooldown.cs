using System;

namespace FallingBombs.Cooldown
{
    public interface ICooldown
    {
        public event Action CooldownStartedEvent;
        public event Action CooldownFinishedEvent;
        public void StartCooldown(float seconds);
    }
}