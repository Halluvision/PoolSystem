using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Halluvision.PoolSystem;

public class Bullet : MonoBehaviour
{
    private Poolable _poolable;

    private void Awake()
    {
        _poolable = GetComponent<Poolable>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        ObjectPoolManager.Instance.PoolObject(_poolable);
    }
}
