using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCollider : MonoBehaviour
{
    //Celing Hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {
            SimplePool.Despawn(collision.gameObject);
        }
    }
}
