using System;
using System.Collections.Generic;
using FallingBombs.Spawnables;
using UnityEngine;

namespace FallingBombs.ObjectPools
{
    public class ObjectPoolContainer : MonoBehaviour
    {
        [SerializeField] private int spawnLimit = 1;
        [SerializeField] private bool autoExpand = true;
        private Dictionary<string, MonoObjectPool<SpawnableBase>> _poolDictionary;

        private void Awake()
        {
            _poolDictionary = new Dictionary<string, MonoObjectPool<SpawnableBase>>();
        }

        public void InitializePoolDicitionary(List<SpawnableBase> spawnPrefabsList)
        {
            foreach (var prefab in spawnPrefabsList)
            {
                if (!_poolDictionary.ContainsKey(prefab.name))
                {
                    var pool = new MonoObjectPool<SpawnableBase>(prefab, spawnLimit);
                    pool.autoExpand = autoExpand;
                    _poolDictionary.Add(prefab.name, pool);
                }
            }
        }
        
        public MonoObjectPool<SpawnableBase> GetConcretePool(string name)
        {
            if (!_poolDictionary.ContainsKey(name))
            {
                throw new Exception($"MonoObjectPool for {name} is missing!");
            }
            else
            {
                return _poolDictionary[name];
            }
        }
        public bool PoolActiveElementsWithinSpawnLimit()
        {
            if (autoExpand)
                return true;
            
            int activePoolObjectsCount = 0;
            foreach (var pool in _poolDictionary)
            {
                activePoolObjectsCount += pool.Value.GetActiveElements().Count;
            }

            return activePoolObjectsCount < spawnLimit;
        }
    }
}