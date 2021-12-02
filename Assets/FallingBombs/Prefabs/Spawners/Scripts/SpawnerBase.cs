using System;
using System.Collections.Generic;
using FallingBombs.ObjectPools;
using FallingBombs.Spawnables;
using FallingBombs.SpawnZones;
using FallingBombs.SpawnZones.Selectors;
using UnityEngine;
using Random = System.Random;

namespace FallingBombs.Spawners
{
    /// <summary>
    /// Spawns a prefab on LeftMouseButton click
    /// </summary>
    public class SpawnerBase : MonoBehaviour, ISpawner
    {
        [SerializeField] private SpawnZoneSelectorBase spawnZoneSelector;
        [SerializeField] private ObjectPoolContainer poolContainer;
        [SerializeField] private SpawnableBase spawnableComponent;
        private List<MonoBehaviour> _spawnPrefabsList;

        public virtual void Awake()
        {
            if (spawnZoneSelector == null)
                throw new NullReferenceException($"SpawnZoneSelector reference is missing!");
            if (poolContainer == null)
                throw new NullReferenceException($"ObjectPoolContainer reference is missing!");
            if (spawnableComponent == null)
                throw new NullReferenceException($"Spawnable reference is missing!");
        }

        public virtual void Start()
        {
            _spawnPrefabsList = GetAllPrefabs();
            poolContainer.InitializePoolDicitionary(_spawnPrefabsList);
        }

        public virtual void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Spawn();
            }
        }

        public List<MonoBehaviour> GetAllPrefabs()
        {
            if (spawnableComponent == null)
                throw new NullReferenceException($"Spawnable reference is missing!");
            return spawnableComponent.GetAll();
        }

        public MonoBehaviour GetSpawnablePrefab()
        {
            if (spawnableComponent == null)
                throw new NullReferenceException($"Spawnable reference is missing!");
            return spawnableComponent.Pick();
        }

        public virtual void Spawn()
        {
            if (poolContainer.PoolActiveElementsWithinSpawnLimit())
            {
                var prefab = GetSpawnablePrefab();
                {
                    var pool = poolContainer.GetConcretePool(prefab.name);
                    var spawnZone = spawnZoneSelector.PickSpawnZone();
                    var spawnedObject = pool.GetFreeElement();
                    spawnedObject.gameObject.transform.position = spawnZone.GetPoint();
                    spawnedObject.transform.parent = spawnZone.transform;
                }
            }
        }
    }
}