using UnityEngine;

namespace FallingBombs.Prefabs.Characters.Views
{
    public class DamageableConsoleView : DamageableViewBase
    {
        public override void OnRespawn(string id, int respawnHealth)
        {
            Debug.Log($"{id} spawned! Max Health is {respawnHealth}");
        }

        public override void OnDamageTaken(string id, int amount)
        {
            Debug.Log($"{id} took {amount} damage points!");
        }

        public override void OnDeath(string id)
        {
            Debug.Log($"{id} is dead!");
        }
    }
}