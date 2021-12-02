using System;
using System.Collections;
using UnityEngine;

namespace FallingBombs.Cooldown
{
    public class CooldownBase : MonoBehaviour, ICooldown
    {
        public event Action CooldownStartedEvent;
        public event Action CooldownFinishedEvent;
        
        private Coroutine _cooldownRoutine;
        
        public virtual void StartCooldown(float seconds)
        {
            if (_cooldownRoutine == null)
            {
                CooldownStartedEvent?.Invoke();
                StartCoroutine(CooldownRoutine(seconds));
            }
        }

        public virtual IEnumerator CooldownRoutine(float seconds)
        {
            yield return new WaitForSecondsRealtime(seconds);
            CooldownFinishedEvent?.Invoke();
            _cooldownRoutine = null;
        }
        
    }
}