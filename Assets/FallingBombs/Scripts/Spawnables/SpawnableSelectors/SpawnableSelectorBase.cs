using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables.Selectors
{
    public abstract class SpawnableSelectorBase : MonoBehaviour, ISpawnableSelector
    {
        public abstract SpawnableBase Pick();
        public abstract List<SpawnableBase> GetAll();
        public abstract bool Valid();
    }
}