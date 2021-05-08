using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerCollision : MonoBehaviour
{
    [Header ("Player's HP")]
    public int _startHp;
    private int _hp;
    [Header("Cooldown After Hit")]
    public float _bulletCooldown;
    float _bulletTimer;
    [Header("Damage Tag")]
    public string _damageTag;

    private Animator _anim;
    private PlayerController _pc;

    public TMP_Text _hpText;

    void Start()
    {
        _pc = GetComponent<PlayerController>();
        _anim = GetComponentInChildren<Animator>();
        _hp = _startHp;
        _hpText.text = _hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _bulletTimer -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _damageTag && _bulletTimer <= 0)
        {        
            
            _hp -= 1;
            _bulletTimer = _bulletCooldown;
            _hpText.text = _hp.ToString();
            SimplePool.Despawn(collision.gameObject);
            // GameOver
            if(_hp <= 0)
            {
                _hpText.color = Color.red;
                _pc._moveSpeed = 0;
                _pc._canMove = false;
                _anim.SetTrigger("Hasdied");                      
            }
        }
        if(collision.tag == "Enemy")
        {
            _hpText.color = Color.red;
            _hpText.text = "ERROR";
            _pc._moveSpeed = 0;
            _pc._canMove = false;
            _anim.SetTrigger("Hasdied");       
        }
    }
}
