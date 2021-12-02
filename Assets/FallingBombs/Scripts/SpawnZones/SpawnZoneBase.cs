using UnityEngine;

namespace FallingBombs.SpawnZones
{
    public abstract class SpawnZoneBase : MonoBehaviour, ISpawnZone
    {
        public abstract Vector3 GetPoint();
    }
}