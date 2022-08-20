using UnityEngine;

namespace Halluvision.PoolSystem
{
    public class Poolable : MonoBehaviour
    {
        [HideInInspector]
        public int poolableID;

        private bool _isPooled;
        public bool IsPooled
        {
            get { return _isPooled; }
            set { _isPooled = value; gameObject.SetActive(!value); }
        }

        private Transform _poolTrans;
        public Transform PoolTransform { get { return _poolTrans; } set { _poolTrans = value; } }

        private void OnDestroy()
        {
            if (ObjectPoolManager.Instance != null)
                ObjectPoolManager.Instance.RemoveObject(this);
        }
    }
}