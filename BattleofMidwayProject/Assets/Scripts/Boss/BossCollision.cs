using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollision : MonoBehaviour
{
    public int _scoreValue;
    public int _bossInitialHP;
    private int _bossCurrentHP;
    public Animator _anim;
    private BoxCollider2D _bc;
    public EndGame _end;

    private void Start()
    {
        _end = FindObjectOfType<EndGame>();
        _anim = GetComponent<Animator>();
        _bc = GetComponent<BoxCollider2D>();
        _bossCurrentHP = _bossInitialHP;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {
            _bossCurrentHP--;
            SimplePool.Despawn(collision.gameObject);
            if (_bossCurrentHP == 0)
            {
                 ScoreSystem.updateScore(_scoreValue);
                _anim.SetTrigger("hasDied");
            }
        }
    }

    public void DestroyShip()
    {
        _end.endGame();
        Destroy(this.gameObject);
    }
}
