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
        if(transform.position.x < 11.8 && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x < 11.8)
        {
            rb.velocity += new Vector2(5, 0);
        }
        if(transform.position.x > -11.8 && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -11.8)
        {
            rb.velocity += new Vector2(-5, 0);
        }
        if (transform.position.y > -6.4 && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && transform.position.y > -6.4)
        {
            rb.velocity += new Vector2(0, -5); 
        }
        if (transform.position.y < 6.4 && Input.GetKey(KeyCode.W)  || Input.GetKey(KeyCode.UpArrow) && transform.position.y < 6.4)
        {
            rb.velocity += new Vector2(0, 5); 
        }
        
    }
}