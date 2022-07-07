using UnityEngine;

namespace Halluvision.PoolSystem
{
    public static class Pooling
    {
        public static GameObject GetObject(GameObject obj, System.Func<GameObject, GameObject> fallbackMethod)
        {
            var poolable = obj.GetComponent<Poolable>();
            if (ReferenceEquals(poolable, null))
                return fallbackMethod(obj);
            return ObjectPoolManager.Instance.GetObject(poolable).gameObject;
        }

        public static bool TryPool(GameObject obj, System.Func<GameObject, bool> fallbackMethod)
        {
            var poolable = obj.GetComponent<Poolable>();
            if (ReferenceEquals(poolable, null))
                return fallbackMethod(obj);
            return ObjectPoolManager.Instance.PoolObject(poolable);
        }

        public static bool TryPool(GameObject obj)
        {
            return TryPool(obj, DefaultPoolFallback);
        }

        public static GameObject GetObject(GameObject obj)
        {
            return GetObject(obj, DefaultGetObjectFallback);
        }

        private static bool DefaultPoolFallback(GameObject obj)
        {
            try
            {
                Object.Destroy(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static GameObject DefaultGetObjectFallback(GameObject obj)
        {
            return Object.Instantiate(obj);
        }
    }
}