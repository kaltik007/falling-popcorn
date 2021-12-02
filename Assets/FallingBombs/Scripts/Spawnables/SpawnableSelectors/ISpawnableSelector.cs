using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables.Selectors
{
    public interface ISpawnableSelector
    {
        public SpawnableBase Pick();
        public List<SpawnableBase> GetAll();
        public bool Valid();
    }
}