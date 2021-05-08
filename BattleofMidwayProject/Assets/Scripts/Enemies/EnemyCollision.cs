using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Animator _anim;
    private BoxCollider2D _bc;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {
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
