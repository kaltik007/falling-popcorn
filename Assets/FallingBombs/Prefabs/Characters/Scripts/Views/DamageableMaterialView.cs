using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingBombs.Prefabs.Characters.Views
{
    [RequireComponent(typeof (Renderer))]
    public class DamageableMaterialView : DamageableViewBase
    {
        [SerializeField] private Color damageColor;
        [SerializeField] private float blendDuration = 1f;
        private Color _defaultColor;
        private Material _material;
        private Coroutine _blendingColorsRoutine;
        private void Awake()
        {
            InitMaterial();
        }

        private void InitMaterial()
        {
            _material = GetComponent<Renderer>().materials[0];
            _defaultColor = _material.color;
        }

        public IEnumerator TakeDamageRoutine(float duration)
        {
            yield return BlendColors(_defaultColor,damageColor, blendDuration/2);
            yield return new WaitForEndOfFrame(); 
            yield return BlendColors(damageColor,_defaultColor, blendDuration/2);
            
            _blendingColorsRoutine = null;
        }
        
        public IEnumerator BlendColors(Color startColor, Color targetColor, float duration)
        {
            float time = 0;
            while (time < duration)
            {
                _material.color = Color.Lerp(startColor, targetColor, time / duration);
                time += Time.deltaTime;
                yield return null;
            }

            _material.color = targetColor;
        }
        
        public override void OnRespawn(string id, int respawnHealth)
        {
            if (!_material)
                InitMaterial();
            _blendingColorsRoutine = null;
            _material.color = _defaultColor;
        }

        public override void OnDamageTaken(string id, int amount)
        {
            if (_blendingColorsRoutine == null)
                _blendingColorsRoutine = StartCoroutine(TakeDamageRoutine(blendDuration));
        }

        public override void OnDeath(string id)
        {
        }

       
    }
}