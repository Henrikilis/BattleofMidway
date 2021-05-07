using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    private Bullet _b;

    public GameObject[] _muzzles;
    public GameObject _bullet;

    public float fireInterval;
    private float fireRate;

    [Header("Bullet Propreties")]
    public float bulletSpeed;
    public Vector2 bulletVelocity;

    void Start()
    {
        _b = _bullet.GetComponent<Bullet>();
        fireInterval = Random.Range(0, 10);
        fireRate = fireInterval;
        SimplePool.Preload(_bullet, 5);
        _b._velocity = bulletVelocity;
        _b._speed = bulletSpeed;
    }

    
    void FixedUpdate()
    {
        if (fireRate < fireInterval)
            fireRate += Time.deltaTime;
        else if (fireRate >= fireInterval)
        {
            fireRate = 0;
            EnemyShot();
        }
    }

    void EnemyShot()
    {
        fireInterval = Random.Range(0, 10);
        foreach (GameObject obj in _muzzles)
        {       
            GameObject bullet = SimplePool.Spawn(_bullet, obj.gameObject.transform.position, Quaternion.identity);
            _b._velocity = bulletVelocity;
            _b._speed = bulletSpeed;
        }

    }

}
