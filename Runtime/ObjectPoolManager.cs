using System.Collections.Generic;
using UnityEngine;

namespace Halluvision.PoolSystem
{
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        Dictionary<int, ObjectPool> pools = new Dictionary<int, ObjectPool>();

        public Poolable GetObject(Poolable prefab)
        {
            if (prefab.poolableID == 0)
                prefab.poolableID = prefab.GetInstanceID();
            int instanceID = prefab.poolableID;

            if (pools.ContainsKey(instanceID))
                return pools[instanceID].GetObject();

            Transform group = new GameObject(prefab.name + instanceID).transform;
            group.SetParent(transform);

            ObjectPool pool = new ObjectPool(prefab, group);
            pools.Add(instanceID, pool);
            return pool.GetObject();
        }

        public bool PoolObject(Poolable obj)
        {
            if (pools.ContainsKey(obj.poolableID))
                return pools[obj.poolableID].PoolObject(obj);
            return false;
        }

        public void RemoveObject(Poolable obj)
        {
            if (pools.ContainsKey(obj.poolableID))
                pools[obj.poolableID].Remove(obj);
        }
    }
}