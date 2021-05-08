using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private PlayerBullet _playerBullet;

    public void IncreaseSpeed()
    {
        _playerController._moveSpeed += 2;

        if(_playerController._moveSpeed >= 24)
        {
            _playerController._moveSpeed = 24;
        }
    }

    public void IncreaseFireRate()
    {      
       _playerBullet.fireInterval -= 0.2f;

        if(_playerBullet.fireInterval <= 0)
        {
            _playerBullet.fireInterval = 0;
        }
    }
}
