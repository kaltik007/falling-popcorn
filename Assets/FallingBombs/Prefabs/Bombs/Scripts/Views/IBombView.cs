using UnityEngine;

namespace FallingBombs.Bombs.Views
{
    public interface IBombView
    {
        public void OnRespawn(string id, float weight);
        public void OnDetonation(string id, Vector3 detonationPoint);
    }
}