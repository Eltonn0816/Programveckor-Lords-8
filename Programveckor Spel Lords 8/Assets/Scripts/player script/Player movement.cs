using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public AudioSource audioSource;
    //för attack
    bool isAttacking = false;
    Vector2 lastDirection = Vector2.zero;
    public float attackRange = 1.0f;
    public GameObject attackPrefab;
    // senaste attacken
    private float lastKlickTime = 0f;
    // tiden mellan attacker flr dubbel ska räknas 
    private float dubbelKlickTrashehold = 2.5f; 

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
        animator.SetLayerWeight(1, isAttacking ? 0 : 1); 
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
        float currentTime = Time.time;
        isAttacking = true;

        if (currentTime - lastKlickTime <= dubbelKlickTrashehold)
        {
           PlayDoubleClickAttackAnimation();
        }
        else
        {
           PlaySingleClickAttackAnimation();
        }
        lastKlickTime = currentTime; // upptaterad senaste ckick
        
        // attack blockens skript
        if(attackPrefab)
        {
            Vector3 spawnPosition = transform.position + (Vector3)lastDirection * attackRange;
            Instantiate(attackPrefab, spawnPosition, Quaternion.identity); 
        }
       
        Invoke(nameof(EndAttack), 0.717f);
    }
    void EndAttack()
    {
        isAttacking = false;
    }
    void PlayDoubleClickAttackAnimation()
    {
        if (lastDirection == new Vector2(1, 0))
        {
            animator.SetTrigger("dubbel right attack");
            //attack right dubbel
        }
        else if (lastDirection == new Vector2(-1, 0))
        {
            animator.SetTrigger("dubbel attack left");
            //attack left dubbel
        }
        else if (lastDirection == new Vector2(0, 1) || lastDirection == new Vector2(-1, 1) || (lastDirection == new Vector2(1, 1)))
        {
            animator.SetTrigger("dubbel attack up");
            //attack up ( left and right up as well) dubbel
        }
        else if (lastDirection == new Vector2(0, -1) || (lastDirection == new Vector2(1, -1) || (lastDirection == new Vector2(-1, -1))))
        {
            animator.SetTrigger("dubbel attack down");
            //attack down (left and right down as well dubbel
        }
    }
    void PlaySingleClickAttackAnimation()
    {
        if (lastDirection == new Vector2(1, 0))
        {
            animator.SetTrigger("attack right");
            //attack right singel
        }
        else if (lastDirection == new Vector2(-1, 0))
        {
            animator.SetTrigger("attack left");
            //attack left singel
        }
        else if (lastDirection == new Vector2(0, 1) || lastDirection == new Vector2(-1, 1) || (lastDirection == new Vector2(1, 1)))
        {
            animator.SetTrigger("up attack");
            //attack up ( left and right up as well) singel
        }
        else if (lastDirection == new Vector2(0, -1) || (lastDirection == new Vector2(1, -1) || (lastDirection == new Vector2(-1, -1))))
        {
            animator.SetTrigger("attack down");
            //attack down (left and right down as well singel
        }
    }
}