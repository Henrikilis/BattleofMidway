using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int _scoreValue;
    public PowerUpController _pc;
    public Animator _anim;
    private BoxCollider2D _bc;
    private enemyShoot _es;
    private AudioManager _am;

    private void Start()
    {
        _pc = FindObjectOfType<PowerUpController>();
        _anim = GetComponent<Animator>();
        _bc = GetComponent<BoxCollider2D>();
        _es = GetComponent<enemyShoot>();
        _am = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {
            
            int random = Random.Range(0, _pc._powerUps.Capacity);        
            _pc.SpawnPowerUp(_pc._powerUps[random], gameObject.transform.position);
            _am.PlaySound("explosion");
            _bc.enabled = false;
            _es.enabled = false;
            _anim.SetTrigger("EnemyDead");                
        }
        if (collision.tag == "Floor")
        {
            DestroyShip();
        }
    }

    public void DestroyShipWithScore()
    {
        ScoreSystem.updateScore(_scoreValue);
        Destroy(this.gameObject);
    }
    public void DestroyShip()
    {
        Destroy(this.gameObject);
    }

}
