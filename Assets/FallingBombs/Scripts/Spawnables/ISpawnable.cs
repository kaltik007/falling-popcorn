using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Spawnables
{
    public interface ISpawnable
    {
        public MonoBehaviour Pick();
        public List<MonoBehaviour> GetAll();
        public bool Valid();
    }
}