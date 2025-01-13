using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class passiveEnemy : MonoBehaviour
    
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
            
            rb.velocity = new Vector2(Random.Range(-6, 5), Random.Range(-4, 5));
            if(targetTime <= 3)
            {
                targetTime = 0;
            }
        }
        
    }
}
