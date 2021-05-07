using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBullet : MonoBehaviour
{
    public GameObject[] _muzzles;
    private PlayerInputActions _playerInput;

    public GameObject _simpleBullet;

    void Start()
    {
        _playerInput = new PlayerInputActions();
        SimplePool.Preload(_simpleBullet, 30);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
       if(context.performed)
        {
            foreach (GameObject obj in _muzzles)
            {
                SimplePool.Spawn(_simpleBullet, obj.gameObject.transform.position, Quaternion.identity);
            }

        }

    }
    
}
