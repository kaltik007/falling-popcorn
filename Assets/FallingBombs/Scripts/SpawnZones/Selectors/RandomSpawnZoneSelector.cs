using System;

namespace FallingBombs.SpawnZones.Selectors
{
    public class RandomSpawnZoneSelector : SpawnZoneSelectorBase
    {
        private Random _randomizer;
        private void Awake()
        {
            _randomizer = new Random();
            if (!ValidateSpawnZones())
            {
                throw new NullReferenceException($"Spawn zone reference is missing!");
            }
        }
        
        public override SpawnZoneBase PickSpawnZone()
        {
            return PickRandom();
        }

        private SpawnZoneBase PickRandom()
        {
            int randomInt = _randomizer.Next(spawnZones.Count);
            return spawnZones[randomInt];
        }
    }
}