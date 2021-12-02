using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables.Selectors
{
    public class QueueMultiSpawnableSelector : MultiSpawnableSelectorBase
    {
        private Queue<SpawnableBase> _prefabsQueue;

        private void Awake()
        { 
            if (Valid())
                ConvertPrefabsListToQueue();
            else
            {
                throw new NullReferenceException($"Nothing to spawn!");
            }
        }

        public override SpawnableBase Pick()
        {
            return PickQueuedPrefab();
        }

        private void ConvertPrefabsListToQueue()
        {
            _prefabsQueue = new Queue<SpawnableBase>(spawnablePrefabs);
        }

        private SpawnableBase PickQueuedPrefab()
        {
            var dequeuedPrefab = _prefabsQueue.Dequeue();
            _prefabsQueue.Enqueue(dequeuedPrefab);
            
            return dequeuedPrefab;
        }
    }
}