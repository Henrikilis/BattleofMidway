using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {
            // SimplePool.Despawn(this.gameObject);  
            _anim.SetTrigger("EnemyDead");
                 
        }
        if (collision.tag == "Floor")
        {
            //   SimplePool.Despawn(this.gameObject);  
            DestroyShip();
        }
    }

    public void DestroyShip()
    {
        Destroy(this.gameObject);
    }

}
