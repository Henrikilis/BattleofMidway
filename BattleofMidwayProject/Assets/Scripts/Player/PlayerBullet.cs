using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBullet : MonoBehaviour
{
    public GameObject[] _muzzles;
    public GameObject[] _muzzles2;
    private PlayerInputActions _playerInput;
    public GameObject _simpleBullet;

    public float _fireInterval;
    private float _fireRate;

    public int _fireType;
    [Header("Bullet Propreties")]
    public float _bulletSpeed;
    public Vector2 _bulletVelocity;

    void Awake()
    {
        _fireType = 0;
        _playerInput = new PlayerInputActions();
        SimplePool.Preload(_simpleBullet, 30);
        _fireRate = _fireInterval;
    }

    private void FixedUpdate()
    { 
        if (_fireRate < _fireInterval)
            _fireRate += Time.deltaTime;
        else if (_fireRate == _fireInterval)
        {
            _fireRate = _fireInterval;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
       if(context.performed && _fireRate >= _fireInterval)
        {
            spawnBullet();
            _fireRate = 0;
        }

    }

    void spawnBullet()
    {
        if (_fireType == 0)
        {
            foreach (GameObject obj in _muzzles)
            {
                GameObject _bullet = SimplePool.Spawn(_simpleBullet, obj.gameObject.transform.position, Quaternion.identity);
                _bullet.GetComponent<Bullet>().SetMoveDirection(_bulletVelocity, _bulletSpeed);
                _bullet.transform.tag = "FriendlyBullet";
            }
        }
        if (_fireType == 1)
        {
            foreach (GameObject obj in _muzzles2)
            {
               GameObject _bullet = SimplePool.Spawn(_simpleBullet, obj.gameObject.transform.position, Quaternion.identity);
               _bullet.transform.tag = "FriendlyBullet";
               _bullet.GetComponent<Bullet>().SetMoveDirection(_bulletVelocity, _bulletSpeed);
                
            }

        }

    }
    
}
