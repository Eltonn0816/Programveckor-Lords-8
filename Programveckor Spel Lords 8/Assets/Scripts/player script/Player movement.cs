using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb; 
    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // needs rigidbody  
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 0); 
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity += new Vector2(5, 0);
            animator.Play("walk right knight");
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity += new Vector2(-5, 0);
            animator.Play("knight walking left");
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity += new Vector2(0, -5);
            animator.Play("walking back knight");
        }
        if (Input.GetKey(KeyCode.W)  || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity += new Vector2(0, 5);
            animator.Play("walking farward");
        }
        else 
        {
           // animator.Play("idel knight");
        }
        
    }
}