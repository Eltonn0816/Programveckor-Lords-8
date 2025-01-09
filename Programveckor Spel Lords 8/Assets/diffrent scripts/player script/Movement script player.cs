using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //needs rigidbody  
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 0); 
        if(Input.GetKey(KeyCode.D) && transform.position.x < 8.45) 
        {
            rb.velocity = new Vector2(5, 0);
        }
        if(Input.GetKey(KeyCode.A) && transform.position.x > -8.45)
        {
            rb.velocity = new Vector2(-5, 0);
        }
        if(Input.GetKey(KeyCode.S) && transform.position.y > -4.45)
        {
            rb.velocity = new Vector2(0, -5); 
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.45)
        {
            rb.velocity = new Vector2(0, 5); 
        }
    }
}