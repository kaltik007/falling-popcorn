namespace FallingBombs.Prefabs.Characters.Views
{
    public interface IDamageableView
    {
        public void OnRespawn(string id, int respawnHealth);
        public void OnDamageTaken(string id, int amount);
        public void OnDeath(string id);
    }
}