using UnityEngine;

namespace FallingBombs.Bombs
{
    [CreateAssetMenu(fileName = "BombInfo", menuName = "Falling Bombs/New BombInfo", order = 0)]
    public class BombInfo : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private float weight;
        public string Id => id;
        public float Weight => weight;
    }
}