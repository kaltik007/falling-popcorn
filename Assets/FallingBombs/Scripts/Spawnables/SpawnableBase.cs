using System;
using UnityEngine;

namespace FallingBombs.Spawnables
{
    public abstract class SpawnableBase : MonoBehaviour, ISpawnable
    {
        public virtual void OnEnable()
        {
            InitSpawnable();
        }

        public abstract void InitSpawnable();
    }
}