using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public Animator _anim;
    public Bullet _b;
    public Transform _muzzleLeft;
    public Transform _muzzleRight;
    public Transform _muzzleHead;

    public GameObject _bullet;
    public GameObject _projectile;

    [SerializeField]
    private int _bossDecision;

    private bool _isIdle;
    private bool _isAttack1;
    private bool _isAttack2;
    
    [Header("Bullet Propreties")]
    public float bulletSpeed;
    public Vector2 bulletVelocity;

    void Start()
    {
        _anim.GetComponent<Animator>();
        _isIdle = true;
        _isAttack1 = false;
        _isAttack2 = false;
        _b = _bullet.GetComponent<Bullet>();
        SimplePool.Preload(_bullet, 5);
    }

    
    void FixedUpdate()
    {
        _b._velocity = bulletVelocity;
        _b._speed = bulletSpeed;

        _anim.SetBool("Attack1", _isAttack1);
        _anim.SetBool("Attack2", _isAttack2);


        if (_bossDecision < 4)
        {
            _isIdle = true;
            _isAttack1 = false;
            _isAttack2 = false;
        }
        else if(_bossDecision > 3 && _bossDecision < 8)
        {
            _isIdle = false;
            _isAttack1 = true;
            _isAttack2 = false;
        }
        else if(_bossDecision >= 8)
        {
            _isIdle = false;
            _isAttack1 = false;
            _isAttack2 = true;
        }
    }

    void ShootLeft()
    {
        GameObject bullet = SimplePool.Spawn(_bullet, _muzzleLeft.gameObject.transform.position, Quaternion.identity);
    }

    void ShootRight()
    {
        GameObject bullet = SimplePool.Spawn(_bullet, _muzzleRight.gameObject.transform.position, Quaternion.identity);
    }

    void ShootHead()
    {


    }

    void ResetFire()
    {  
        _bossDecision = Random.Range(0, 10);
    }
}
