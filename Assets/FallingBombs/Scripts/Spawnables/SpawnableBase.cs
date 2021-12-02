using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables
{
    public abstract class SpawnableBase : MonoBehaviour, ISpawnable
    {
        public abstract MonoBehaviour Pick();
        public abstract List<MonoBehaviour> GetAll();
        public abstract bool Valid();
    }
}