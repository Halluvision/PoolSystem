using System.Collections.Generic;
using UnityEngine;

namespace Halluvision.PoolSystem
{
    public class ObjectPool
    {
        private List<Poolable> _pool = new List<Poolable>();
        private Poolable _prefab;
        private Transform _group;

        public ObjectPool(Poolable prefab, Transform group)
        {
            _prefab = prefab;
            _group = group;
        }

        public Poolable GetObject()
        {
            Poolable obj;
            int numberOfItems = _pool.Count;
            if (numberOfItems > 0)
            {
                obj = _pool[numberOfItems - 1];
                obj.IsPooled = false;
                _pool.RemoveAt(numberOfItems - 1);
            }
            else
            {
                obj = Object.Instantiate(_prefab);
                obj.transform.parent = _group;
            }
            return obj;
        }

        public bool PoolObject(Poolable obj)
        {
            if (obj.poolableID == _prefab.poolableID && !obj.IsPooled)
            {
                _pool.Add(obj);
                obj.IsPooled = true;
                return true;
            }
            return false;
        }

        public void Remove(Poolable obj)
        {
            if (_pool.Contains(obj))
                _pool.Remove(obj);
        }
    }
}