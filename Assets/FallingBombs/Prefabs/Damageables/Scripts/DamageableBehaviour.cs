using System;
using System.Collections.Generic;
using FallingBombs.Damageables.Views;
using FallingBombs.Spawnables;
using UnityEngine;

namespace FallingBombs.Damageables
{
    public class DamageableBehaviour : SpawnableBase
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

        public override void OnEnable()
        {
            base.OnEnable();
            
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
        
        public override void InitSpawnable()
        {
            InitDamageable();
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