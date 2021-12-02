using System.Collections.Generic;
using FallingBombs.SpawnZones;
using UnityEngine;
namespace FallingBombs.Spawners
{
    public interface ISpawner
    {
        public MonoBehaviour GetSpawnablePrefab();
        public List<MonoBehaviour> GetAllPrefabs();
        public void Spawn();
    }
}