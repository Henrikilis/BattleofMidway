using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBullet : MonoBehaviour
{
    public GameObject[] _muzzles;
    private PlayerInputActions _playerInput;
    private Bullet _b;
    public GameObject _simpleBullet;

    public float fireInterval;
    private float fireRate;

    [Header("Bullet Propreties")]
    public float bulletSpeed;
    public Vector2 bulletVelocity;

    void Start()
    {
        _b = _simpleBullet.GetComponent<Bullet>();
        _playerInput = new PlayerInputActions();
        SimplePool.Preload(_simpleBullet, 30);
        fireRate = fireInterval;       
    }

    private void FixedUpdate()
    {
        _b._velocity = bulletVelocity;
        _b._speed = bulletSpeed;

        if (fireRate < fireInterval)
            fireRate += Time.deltaTime;
        else if (fireRate == fireInterval)
        {
            fireRate = fireInterval;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
       if(context.performed && fireRate >= fireInterval)
        {
            spawnBullet();
            fireRate = 0;
        }

    }

    void spawnBullet()
    {

        foreach (GameObject obj in _muzzles)
        {
           GameObject bullet  = SimplePool.Spawn(_simpleBullet, obj.gameObject.transform.position, Quaternion.identity);          
            bullet.transform.tag = "FriendlyBullet";
        }
        

    }
    
}
