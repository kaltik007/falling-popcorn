using System;
using UnityEngine;
using Random = System.Random;

namespace FallingBombs.Spawnables
{
    public class RandomMultiSpawnable : MultiSpawnableBase
    {
        private Random _randomizer;
        private void Awake()
        {
            _randomizer = new Random();
            if (!Valid())
            {
                throw new NullReferenceException($"Nothing to spawn!");
            }
        }
        
        public override MonoBehaviour Pick()
        {
            return GetRandomPrefab();
        }

        private MonoBehaviour GetRandomPrefab()
        {
            int randomInt = _randomizer.Next(spawnablePrefabs.Count);
            return spawnablePrefabs[randomInt];
        }
        
    }
}