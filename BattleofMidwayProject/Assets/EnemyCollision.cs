using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {
            SimplePool.Despawn(this.gameObject);
           
        }
    }
}
