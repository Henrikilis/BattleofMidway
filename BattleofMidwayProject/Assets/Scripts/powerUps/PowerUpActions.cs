using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private PlayerBullet _playerBullet;
    [SerializeField]
    private playerCollision _playerCollision;

    public void IncreaseSpeed()
    {
        _playerController._moveSpeed += 1;
        if(_playerController._moveSpeed >= 14)
        {
            _playerController._moveSpeed = 15;
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
    public void Heal()
    {
       if( _playerCollision._hp < 3)
        {
            _playerCollision._hp++;
            _playerCollision._hpText.text = _playerCollision._hp.ToString();
        }
    }
    public void MoreShots()
    {


    }
}
