using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    //för attack
    public Transform Aim;
    bool isMoving = false; 

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

        Vector2 movement = Vector2.zero;
        float speed = 5f; 

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            animator.Play("right up knight walk");
            movement = new Vector2(1, 1);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            animator.Play("walk left up");
            movement = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement = new Vector2(1, 0);
            animator.Play("walk right knight");
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement = new Vector2(-1, 0);
            animator.Play("knight walking left");
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement = new Vector2(0, -1);
            animator.Play("walking back knight");
        }
        else if (Input.GetKey(KeyCode.W)  || Input.GetKey(KeyCode.UpArrow))
        {
            movement = new Vector2(0, 1);
            animator.Play("walking farward");
        }
        else 
        {
            animator.Play("idel knight"); 
        }
        if (movement != Vector2.zero)
        {
            movement = movement .normalized * speed; 
        }
        rb.velocity = movement;
    }
}