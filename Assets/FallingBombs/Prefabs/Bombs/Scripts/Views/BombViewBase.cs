using UnityEngine;

namespace FallingBombs.Bombs.Views
{
    public abstract class BombViewBase : MonoBehaviour, IBombView
    {
        public abstract void OnRespawn(string id, float weight);

        public abstract void OnDetonation(string id, Vector3 detonationPoint);
    }
}