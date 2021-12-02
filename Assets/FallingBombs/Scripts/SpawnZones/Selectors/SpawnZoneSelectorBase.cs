using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.SpawnZones.Selectors
{
    public abstract class SpawnZoneSelectorBase : MonoBehaviour, ISpawnZoneSelector
    {
        [SerializeField] protected List<SpawnZoneBase> spawnZones;
        public abstract SpawnZoneBase PickSpawnZone();

        public virtual bool ValidateSpawnZones()
        {
            bool isValid = false;
            for (int i = 0; i < spawnZones.Count; i++)
            {
                if (spawnZones[i] == null)
                    spawnZones.Remove(spawnZones[i]);
                else
                    isValid = true;
            }

            return isValid;
        }
        
    }
}