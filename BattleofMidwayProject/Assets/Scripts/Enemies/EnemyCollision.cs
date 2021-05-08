using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public PowerUpController _pc;
    public Animator _anim;
    private BoxCollider2D _bc;
    [SerializeField]
    private int _spawnChance;

    private void Start()
    {
        _pc = FindObjectOfType<PowerUpController>();
        _anim = GetComponent<Animator>();
        _bc = GetComponent<BoxCollider2D>();
        _spawnChance = Random.Range(1, 6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {

            int random = Random.Range(0, _pc._powerUps.Capacity);        
            _pc.SpawnPowerUp(_pc._powerUps[random], gameObject.transform.position);

            _bc.enabled = false;
            _anim.SetTrigger("EnemyDead");                
        }
        if (collision.tag == "Floor")
        {
            DestroyShip();
        }
    }

    public void DestroyShip()
    {
        Destroy(this.gameObject);
    }

}
