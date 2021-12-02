using UnityEngine;

namespace FallingBombs.SpawnZones
{
    public class PointSpawnZone : SpawnZoneBase
    {
        //[SerializeField] private DeactivateableContainerBase zoneContainer;
        private Vector3 _point;
        private bool _zoneAvailableToSpawn;

        private void Awake()
        {
            _point = gameObject.transform.position;
        }

        public override Vector3 GetPoint()
        {
            return _point;
        }

        private void OnContainerReleased()
        {
            _zoneAvailableToSpawn = true;
        }

        private void OnContainerFilled()
        {
            _zoneAvailableToSpawn = false;
        }
    }
}