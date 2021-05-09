using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    public PowerUpController _controller;
    private AudioManager _am;

    [SerializeField]
    private PowerUp _powerUp;

    private Transform _transform;
 
    private void Awake()
    {
        _transform = transform;
        _am = FindObjectOfType<AudioManager>();

    }

    private void ActivatePowerup()
    {
        _controller.ActivatePowerUp(_powerUp);
    }

    public void SetPowerup(PowerUp powerUp)
    {
        this._powerUp = powerUp;

        gameObject.name = powerUp._name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            _am.PlaySound("powerup");
            ActivatePowerup();
            gameObject.SetActive(false);
        }     
    }
}
