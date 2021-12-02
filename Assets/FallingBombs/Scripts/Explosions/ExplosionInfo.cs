using UnityEngine;

namespace FallingBombs.Explosions
{
    [CreateAssetMenu(fileName = "ExplosionInfo", menuName = "Falling Bombs/New ExplosionInfo", order = 0)]
    public class ExplosionInfo : ScriptableObject
    {
        [SerializeField] private float radius;
        [SerializeField] private int damage;

        public float Radius => radius;
        public int Damage => damage;
    }
}