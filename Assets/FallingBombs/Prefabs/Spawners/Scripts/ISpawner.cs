using System.Collections.Generic;
using FallingBombs.Spawnables;
using FallingBombs.SpawnZones;
using UnityEngine;
namespace FallingBombs.Spawners
{
    public interface ISpawner
    {
        public SpawnableBase GetSpawnablePrefab();
        public List<SpawnableBase> GetAllPrefabs();
        public void Spawn();
    }
}