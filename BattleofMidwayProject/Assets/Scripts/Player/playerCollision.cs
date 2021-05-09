using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerCollision : MonoBehaviour
{
    [Header ("Player's HP")]
    public int _startHp;
    public int _hp;
    [Header("Cooldown After Hit")]
    public float _bulletCooldown;
    float _bulletTimer;
    [Header("Damage Tag")]
    public string _damageTag;

    private Animator _anim;
    private PlayerController _pc;
    private AudioManager _am;
    public TMP_Text _hpText;
    private SpriteRenderer _sr;

    void Start()
    {
        _pc = GetComponent<PlayerController>();
        _anim = GetComponentInChildren<Animator>();
        _sr = GetComponentInChildren<SpriteRenderer>();
        _hp = _startHp;
        _hpText.text = _hp.ToString();
        _am = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _bulletTimer -= Time.deltaTime;

        if(_bulletTimer > 0)
        _sr.color = new Color(1f, 1f, 1f,.6f);
        else
        _sr.color = new Color(1f, 1f, 1f,1f);



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
                _am.PlaySound("gameover");
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
