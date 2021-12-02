
using System;
using TMPro;
using UnityEngine;

namespace FallingBombs.Prefabs.Characters.Views
{
    public class DamageableTextMeshProView : DamageableViewBase
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color damageColor;
        [SerializeField] private Animator tmAnimator;
        private void Awake()
        {
            if (textMesh == null)
                throw new NullReferenceException($"Missing TMPro object refference!");
        }

        public override void OnRespawn(string id, int respawnHealth)
        {
        }

        public override void OnDamageTaken(string id, int amount)
        {
            UpdateText(amount.ToString(), damageColor);
        }

        public override void OnDeath(string id)
        {
        }

        private void UpdateText(string newValue, Color newColor)
        {
            textMesh.text = newValue;
            textMesh.color = newColor;
        }
    }
}