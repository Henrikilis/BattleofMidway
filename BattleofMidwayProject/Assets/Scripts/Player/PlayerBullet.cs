using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBullet : MonoBehaviour
{
    public GameObject[] _muzzles;
    private PlayerInputActions _playerInput;

    public GameObject _simpleBullet;

    public float fireInterval;
    [SerializeField]
    private float fireRate;

    void Start()
    {
        _playerInput = new PlayerInputActions();
        SimplePool.Preload(_simpleBullet, 30);
        fireRate = fireInterval;

        foreach (GameObject obj in _muzzles)
        {
            obj.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        
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
