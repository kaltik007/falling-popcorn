using System;
using UnityEngine;

namespace FallingBombs.Prefabs.Bombs
{
    public interface IBomb
    {
        public event Action<string, float> RespawnEvent;
        public event Action<string, Vector3> DetonationEvent;
        public void Detonate(Vector3 detonationPoint);
    }
}