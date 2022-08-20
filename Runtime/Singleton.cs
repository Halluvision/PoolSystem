using UnityEngine;

namespace Halluvision.PoolSystem
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public bool isPersistant;
        protected static T instance;
        private static bool isApplicationQuitting = false;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    if (isApplicationQuitting)
                        return null;
                    var obj = new GameObject(typeof(T).Name, typeof(T)).GetComponent<T>();
                    instance = obj;
                    if (obj.isPersistant)
                        DontDestroyOnLoad(obj);
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (!instance)
            {
                instance = gameObject.GetComponent<T>();
                if (isPersistant)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (instance != gameObject.GetComponent<T>())
                    Destroy(gameObject);
            }
        }

        protected virtual void OnApplicationQuit()
        {
            isApplicationQuitting = true;
        }
    }
}