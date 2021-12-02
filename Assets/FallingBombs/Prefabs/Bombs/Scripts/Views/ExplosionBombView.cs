using System;
using FallingBombs.Explosions;
using UnityEngine;

namespace FallingBombs.Bombs.Views
{
    public class ExplosionBombView : BombViewBase
    {
        [SerializeField] private ExplosionInfo explosionInfo;
        private IExplosion _explosion;

        private void Awake()
        {
            if (explosionInfo == null)
                throw new NullReferenceException($"ExplosionInfo reference is missing!");
            _explosion = new SimpleExplosion(explosionInfo);
        }

        public override void OnRespawn(string id, float weight)
        {
        }

        public override void OnDetonation(string id, Vector3 detonationPoint)
        {
            _explosion.DealDamage(detonationPoint);
        }
    }
}