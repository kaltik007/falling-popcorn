using System;
using System.Collections.Generic;
using FallingBombs.Prefabs.Characters.Views;
using UnityEngine;

namespace FallingBombs.Prefabs.Characters
{
    public class DamageableBehaviour : MonoBehaviour
    {
        [SerializeField] private DamageableInfo damageableInfo;
        [SerializeField] private List<DamageableViewBase> damageableViews;
        private IDamageable _damageable;

        private void Awake()
        {
            if (damageableViews.Count > 0)
            {
                foreach (var view in damageableViews)
                {
                    if (view == null)
                    {
                        damageableViews.Remove(view);
                    }
                    else
                    {
                        view.SetDamageableBehaviour(this);
                    }
                }
            }
        }

        private void OnEnable()
        {
            InitDamageable();
            _damageable.RespawnEvent += OnRespawn;
            _damageable.DamageTakenEvent += OnDamageTaken;
            _damageable.DeathEvent += OnDeath;
            
            _damageable.Respawn();
        }
        private void OnDisable()
        {
            _damageable.RespawnEvent -= OnRespawn;
            _damageable.DamageTakenEvent -= OnDamageTaken;
            _damageable.DeathEvent -= OnDeath;
        }
        
        private void InitDamageable()
        {
            if (damageableInfo == null)
                throw new NullReferenceException("CharacterInfo is missing! Can't initialize character");

            _damageable = new Damageable(damageableInfo);
        }
        
        public void TakeDamage(object sender, int damage)
        {
            _damageable.TakeDamage(sender, damage);
        }

        private void OnDeath()
        {
            foreach (var view in damageableViews)
            {
                view.OnDeath(_damageable.Id);
            }
            gameObject.SetActive(false);
        }

        private void OnDamageTaken(int amount)
        {
            foreach (var view in damageableViews)
            {
                view.OnDamageTaken(_damageable.Id, amount);
            }
        }

        private void OnRespawn(int respawnHealth)
        {
            foreach (var view in damageableViews)
            {
                view.OnRespawn(_damageable.Id, respawnHealth);
            }
        }
    }
}