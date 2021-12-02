using System;
using System.Collections.Generic;
using FallingBombs.Bombs.Views;
using FallingBombs.Spawnables;
using UnityEngine;

namespace FallingBombs.Bombs
{
    public class BombBehaviour : SpawnableBase
    {
        [SerializeField] private BombInfo bombInfo;
        [SerializeField] private List<BombViewBase> bombViews;

        private IBomb _bomb;
        
        public override void OnEnable()
        {
            base.OnEnable();
            
            _bomb.RespawnEvent += OnRespawn;
            _bomb.DetonationEvent += OnDetonation;
        }

        private void OnDisable()
        {
            _bomb.RespawnEvent -= OnRespawn;
            _bomb.DetonationEvent -= OnDetonation;
        }

        public override void InitSpawnable()
        {
            InitBomb();
        }
        
        private void InitBomb()
        {
            if (bombInfo == null)
                throw new NullReferenceException($"BombInfo reference is missing!");
            _bomb = new Bomb(bombInfo);
        }

        private void OnRespawn(string id, float bombWeight)
        {
            foreach (var bombView in bombViews)
            {
                bombView.OnRespawn(id, bombWeight);
            }
        }

        private void OnDetonation(string id, Vector3 detonationPoint)
        {
            foreach (var bombView in bombViews)
            {
                bombView.OnDetonation(id, detonationPoint);
            }
        }


        private void OnCollisionEnter(Collision other)
        {
            _bomb.Detonate(gameObject.transform.position);
            gameObject.SetActive(false);
        }
    }
}