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
            Debug.Log("matei");
        }
        if (collision.tag == "Floor")
        {
            SimplePool.Despawn(this.gameObject);
            Debug.Log("Hit my head");
        }
    }
}
