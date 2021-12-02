using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables.Selectors
{
    public class SingleSpawnableSelector : SpawnableSelectorBase
    {
        [SerializeField] private SpawnableBase spawnablePrefab;

        public void Awake()
        {
            if (!Valid())
                throw new NullReferenceException("Nothing to spawn!");
        }
        public override SpawnableBase Pick()
        {
            if (Valid())
            {
                return spawnablePrefab;
            }
            else
            {
                throw new NullReferenceException("Nothing to spawn!");
            }
        }

        public override List<SpawnableBase> GetAll()
        {
            if (Valid())
            {
                List<SpawnableBase> result = new List<SpawnableBase>(){Pick()};
                return result;
            }
            else
            {
                throw new NullReferenceException("Nothing to spawn!"); 
            }
        }

        public override bool Valid()
        {
            return spawnablePrefab != null;
        }
    }
}