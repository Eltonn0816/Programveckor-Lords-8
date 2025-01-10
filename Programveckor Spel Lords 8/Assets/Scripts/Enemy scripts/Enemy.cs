using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
    
{
    Rigidbody2D rb; public float targetTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        targetTime += Time.deltaTime;
        if (targetTime >= 1f)
        {
            rb.velocity = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            if(targetTime <= 3)
            {
                targetTime = 0;
            }
        }
        
    }
}
