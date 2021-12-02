using UnityEngine;
using Random = UnityEngine.Random;

namespace FallingBombs.SpawnZones
{
    [RequireComponent(typeof(BoxCollider))]
    public class BoxColliderSpawnZone : SpawnZoneBase
    {
        private BoxCollider _collider;
        
        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
        }

        public override Vector3 GetPoint()
        {
            return GetRandomPointInBoxCollider();
        }

        private Vector3 GetRandomPointInBoxCollider()
        {
            Vector3 extents = _collider.size / 2f;
            Vector3 newPoint = new Vector3(
                Random.Range( -extents.x, extents.x ),
                Random.Range( -extents.y, extents.y ),
                Random.Range( -extents.z, extents.z )
            )  + _collider.center;

            return gameObject.transform.TransformPoint(newPoint);
        }
    }
}
