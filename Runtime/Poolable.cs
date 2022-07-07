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

        private void OnDestroy()
        {
            ObjectPoolManager.Instance.RemoveObject(this);
        }
    }
}