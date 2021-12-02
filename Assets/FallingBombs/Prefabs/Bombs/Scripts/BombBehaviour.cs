using System;
using System.Collections.Generic;
using FallingBombs.Prefabs.Bombs.Views;
using FallingBombs.Scripts.Explosions;
using UnityEngine;

namespace FallingBombs.Prefabs.Bombs
{
    public class BombBehaviour : MonoBehaviour
    {
        [SerializeField] private BombInfo bombInfo;
        [SerializeField] private List<BombViewBase> bombViews;

        private IBomb _bomb;
        
        private void OnEnable()
        {
            InitBomb();
            _bomb.RespawnEvent += OnRespawn;
            _bomb.DetonationEvent += OnDetonation;
        }

        private void OnDisable()
        {
            _bomb.RespawnEvent -= OnRespawn;
            _bomb.DetonationEvent -= OnDetonation;
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

        private void InitBomb()
        {
            if (bombInfo == null)
                throw new NullReferenceException($"BombInfo reference is missing!");
            _bomb = new Bomb(bombInfo);
        }
    }
}