using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FallingBombs.ObjectPools
{
    public class MonoObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        public T objectPrefab { get; }
        public bool autoExpand { get; set; }
        public Transform poolContainer { get; }

        private List<T> _objectPool;

        public MonoObjectPool(T prefab, int capacity)
        {
            objectPrefab = prefab;
            poolContainer = null;
            CreatePool(capacity);
        }

        public MonoObjectPool(T prefab, int capacity, Transform container)
        {
            objectPrefab = prefab;
            poolContainer = container;
            CreatePool(capacity);
        }

        public bool HasFreeElement(out T freeElement)
        {
            foreach (var element in _objectPool)
            {
                if (!element.gameObject.activeInHierarchy)
                {
                    element.gameObject.SetActive(true);
                    freeElement = element;
                    return true;
                }
            }

            freeElement = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out T freeElement))
                return freeElement;

            if (autoExpand)
                return CreateObject((true));

            return null;
        }
        
        public List<T> GetActiveElements()
        {
            List<T> activeElements = new List<T>();
            foreach (var element in _objectPool)
            {
                if (element.gameObject.activeInHierarchy)
                {
                    activeElements.Add(element);
                }
            }

            return activeElements;
        }

        private void CreatePool(int capacity)
        {
            _objectPool = new List<T>();
            for (int i = 0; i < capacity; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var newObject = Object.Instantiate(objectPrefab, poolContainer);
            newObject.gameObject.SetActive(isActiveByDefault);
            _objectPool.Add(newObject);
            return newObject;
        }
    }
}