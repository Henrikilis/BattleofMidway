using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    public float _BackgroundSpeed;
    

  
    void Update()
    {
        transform.Translate(0, _BackgroundSpeed * Time.deltaTime, 0);
    }
}
