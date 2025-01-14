using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public AudioSource audioSource;
    //för attack
    Vector2 lastDirection = Vector2.zero;
    public float attackRange = 1.0f;
    public GameObject attackPrefab;

    Animator animator;
    Rigidbody2D rb;
    public float speed = 5f;

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // needs rigidbody  
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 movement = Vector2.zero; 

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            animator.Play("right up knight walk");
            movement = new Vector2(1, 1);
            audioSource.mute = false;
            lastDirection = movement.normalized;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            animator.Play("walk left up");
            movement = new Vector2(-1, 1);
            audioSource.mute = false;
            lastDirection = movement.normalized;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            animator.Play("down left walk");
            movement = new Vector2(-1, -1);
            audioSource.mute = false;
            lastDirection = movement.normalized;
        } else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            animator.Play("knight right down walk");
            movement = new Vector2(1, -1);
            audioSource.mute = false;
            lastDirection = movement.normalized;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement = new Vector2(1, 0);
            animator.Play("walk right knight");
            audioSource.mute = false;
            lastDirection = movement.normalized;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement = new Vector2(-1, 0);
            animator.Play("knight walking left");
            audioSource.mute = false;
            lastDirection = movement.normalized;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement = new Vector2(0, -1);
            animator.Play("walking back knight");
            audioSource.mute = false;
            lastDirection = movement.normalized;
        }
        else if (Input.GetKey(KeyCode.W)  || Input.GetKey(KeyCode.UpArrow))
        {
            movement = new Vector2(0, 1);
            animator.Play("walking farward");
            audioSource.mute = false;
            lastDirection = movement.normalized;
        }
        else if (lastDirection == new Vector2(1, 0))

        {
            animator.Play("idel right");
            audioSource.mute = true;
            //idel right
        }
        else if (lastDirection == new Vector2(-1, 0))
        {
            animator.Play("idel left");
            audioSource.mute = true;
            //idel left
        }
        else if (lastDirection == new Vector2(0, 1) || lastDirection == new Vector2(-1, 1) || (lastDirection == new Vector2(1, 1)))
        {
            animator.Play("idel front");
            audioSource.mute = true;
            //idel up ( left and right up as well) 
        }
        else if (lastDirection == new Vector2(0, -1) || (lastDirection == new Vector2(1, -1) || (lastDirection == new Vector2(-1, -1))))
        {
            animator.Play("idel back");
            audioSource.mute = true;
            //idel down (left and right down as well
        }

        if (movement != Vector2.zero)
        {
            movement = movement.normalized * speed; 
        }
        rb.velocity = movement;
        // kollar om vi trycker på space
        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
    }
    void attack()
    {
        if (lastDirection == new Vector2(1, 0))
        {
            animator.Play("");
            //attack right
        }
        else if (lastDirection == new Vector2(-1, 0))
        {
            animator.Play("");
            //attack left
        }
        else if (lastDirection == new Vector2(0, 1) || lastDirection == new Vector2(-1, 1) || (lastDirection == new Vector2(1, 1)))
        {
            animator.Play("");
            //attack up ( left and right up as well) 
        }
        else if (lastDirection == new Vector2(0,-1) || (lastDirection == new Vector2(1, -1) || (lastDirection == new Vector2(-1, -1))))
        {
            animator.Play(""); 
            //attack down (left and right down as well
        }
        
        // attack blockens skript
        if(attackPrefab)
        {
            Vector3 spawnPosition = transform.position + (Vector3)lastDirection * attackRange;
            Instantiate(attackPrefab, spawnPosition, Quaternion.identity); 
        }


    }
}