using UnityEngine;

namespace FallingBombs.SpawnZones
{
    public interface ISpawnZone
    {
        public Vector3 GetPoint();
    }
}