namespace FallingBombs.SpawnZones.Selectors
{
    public interface ISpawnZoneSelector
    {
        public SpawnZoneBase PickSpawnZone();
        public bool ValidateSpawnZones();
    }
}