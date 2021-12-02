using System;
using FallingBombs.Cooldown;
using UnityEngine;

namespace FallingBombs.Spawners
{
    /// <summary>
    /// Spawns prefab on timer cooldown
    /// </summary>
    public class AutoSpawner : SpawnerBase
    {
        [SerializeField] private CooldownBase cooldownContainer;
        [SerializeField] private float cooldownTime = 1f;

        private void OnEnable()
        {
            cooldownContainer.CooldownFinishedEvent += OnCooldownFinished;
        }

        private void OnDisable()
        {
            cooldownContainer.CooldownFinishedEvent -= OnCooldownFinished;
        }

        public override void Awake()
        {
            base.Awake();
            if (cooldownContainer == null)
                throw new NullReferenceException($"Cooldown reference is missing!");
        }

        public override void Start()
        {
            base.Start();
            cooldownContainer.StartCooldown(cooldownTime);
        }

        public override void Update()
        {
        }

        public override void Spawn()
        {
            base.Spawn();
            cooldownContainer.StartCooldown(cooldownTime);
        }

        private void OnCooldownFinished()
        {
           Spawn();
        }

    }
}