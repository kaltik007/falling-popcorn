using System;
using UnityEngine;
using Random = System.Random;

namespace FallingBombs.Spawnables.Selectors
{
    public class RandomMultiSpawnableSelector : MultiSpawnableSelectorBase
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
        
        public override SpawnableBase Pick()
        {
            return GetRandomPrefab();
        }

        private SpawnableBase GetRandomPrefab()
        {
            int randomInt = _randomizer.Next(spawnablePrefabs.Count);
            return spawnablePrefabs[randomInt];
        }
        
    }
}