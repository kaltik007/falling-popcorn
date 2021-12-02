using System;
using FallingBombs.Scripts.Explosions;
using UnityEngine;

namespace FallingBombs.Prefabs.Bombs
{
    public class Bomb : IBomb
    {
        public event Action<string, float> RespawnEvent;
        public event Action<string, Vector3> DetonationEvent;

        private string _id;
        private float _weight;

        public string Id => _id;
        public float Weight => _weight;

        public Bomb(BombInfo bombInfo)
        {
            _id = bombInfo.Id;
            _weight = bombInfo.Weight;
            Respawn();
        }

        public void Respawn()
        {
            RespawnEvent?.Invoke(_id, _weight);
        }
        
        public void Detonate(Vector3 detonationPoint)
        {
            DetonationEvent?.Invoke(_id, detonationPoint);
        }
    }
}