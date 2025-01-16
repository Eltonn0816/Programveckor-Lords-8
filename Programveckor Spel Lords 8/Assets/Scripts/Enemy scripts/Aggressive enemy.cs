using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggressive : MonoBehaviour
{
    public Transform player;
    public float speed = 4f;
    Animator animator;
    private string currentanimation;
    private bool playerIsClose = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
        else { playerIsClose = false; }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
       
        string newanimation = null;
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        direction = direction.normalized * speed;
        if (Mathf.Abs(player.position.x - transform.position.x) > Mathf.Abs(player.position.y - transform.position.y))
        {
           
            if (player.transform.position.x > transform.position.x)
            {
                if (playerIsClose = true)
                {
                    //play vikingattack right
                }
                newanimation = "vikingwalkRW";
            }

            else
            { newanimation = "vikingwalkLW"; }
        }
        else
        {
            if (player.transform.position.y > transform.position.y)
            {
                if (playerIsClose = true)
                {
                    newanimation = "vikingattackBW";
                }
                else { newanimation = "vikingwalkBW"; }
            }

            else
            {

                if (playerIsClose = true)
                {
                    newanimation = "vikingattackFW";
                }
                else { newanimation = "vikingwalkFW"; }
            }
        }

        if (newanimation != null && newanimation != currentanimation)
        {
            animator.Play(newanimation);
            currentanimation = newanimation;
        }


    }
}
