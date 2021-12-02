using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables
{
    public class SingleSpawnable : SpawnableBase
    {
        [SerializeField] private MonoBehaviour spawnablePrefab;

        public void Awake()
        {
            if (!Valid())
                throw new NullReferenceException("Nothing to spawn!");
        }
        public override MonoBehaviour Pick()
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

        public override List<MonoBehaviour> GetAll()
        {
            if (Valid())
            {
                List<MonoBehaviour> result = new List<MonoBehaviour>(){Pick()};
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