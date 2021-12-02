using UnityEngine;

namespace FallingBombs.Damageables
{
    [CreateAssetMenu(fileName = "CharacterInfo", menuName = "Falling Bombs/New CharacterInfo", order = 0)]
    public class DamageableInfo : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private int health;

        public string Id => id;
        public int Health => health;
    }
}