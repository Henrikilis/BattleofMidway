using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    [Header ("Player's HP")]
    public int _startHp;
    private int _hp;
    [Header("Cooldown After Hit")]
    public float _bulletCooldown;
    float _bulletTimer;

    void Start()
    {
        _hp = _startHp;
    }

    // Update is called once per frame
    void Update()
    {
        _bulletTimer -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hostile" && _bulletTimer <= 0)
        {
            _hp -= 1;
            _bulletTimer = _bulletCooldown;
        }
    }
}
