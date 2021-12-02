using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables
{
    public class QueueMultiSpawnable : MultiSpawnableBase
    {
        private Queue<MonoBehaviour> _prefabsQueue;

        private void Awake()
        { 
            if (Valid())
                ConvertPrefabsListToQueue();
            else
            {
                throw new NullReferenceException($"Nothing to spawn!");
            }
        }

        public override MonoBehaviour Pick()
        {
            return PickQueuedPrefab();
        }

        private void ConvertPrefabsListToQueue()
        {
            _prefabsQueue = new Queue<MonoBehaviour>(spawnablePrefabs);
        }

        private MonoBehaviour PickQueuedPrefab()
        {
            var dequeuedPrefab = _prefabsQueue.Dequeue();
            _prefabsQueue.Enqueue(dequeuedPrefab);
            
            return dequeuedPrefab;
        }
    }
}