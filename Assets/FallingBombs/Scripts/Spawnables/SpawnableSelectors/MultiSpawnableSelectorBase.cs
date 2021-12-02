using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables.Selectors
{
    public abstract class MultiSpawnableSelectorBase : SpawnableSelectorBase
    {
        [SerializeField] protected List<SpawnableBase> spawnablePrefabs;

        public override bool Valid()
        {
            bool isValid = false;
            for (int i = 0; i < spawnablePrefabs.Count; i++)
            {
                if (spawnablePrefabs[i] == null)
                    spawnablePrefabs.Remove(spawnablePrefabs[i]);
                else
                    isValid = true;
            }

            return isValid;
        }

        public override List<SpawnableBase> GetAll()
        {
            if (Valid())
            {
                return spawnablePrefabs;
            }
            else
            {
                throw new NullReferenceException("Nothing to spawn!");
            }
        }
    }
}