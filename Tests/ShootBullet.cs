using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Halluvision.PoolSystem;

public class ShootBullet : MonoBehaviour
{
    [SerializeField]
    private Poolable _bulletPrefab;
    [SerializeField]
    private float _speed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Poolable poolable = ObjectPoolManager.Instance.GetObject(_bulletPrefab);
        poolable.transform.position = new Vector3(0f, 1f, 0f);
        if (poolable.TryGetComponent(out Rigidbody rb))
        {
            rb.velocity = Vector3.forward * _speed;
        }
    }
}
