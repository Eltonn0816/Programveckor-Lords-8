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
    public Vector3 movementdirection;
    public enemyknockback knockback;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        knockback = GetComponent<enemyknockback>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }

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
        if (knockback.isknockedback == false)
        {
            Vector3 movementdirection = (player.position - transform.position).normalized;
            transform.position += movementdirection * speed * Time.deltaTime;
            movementdirection = movementdirection.normalized * speed;
            if (Mathf.Abs(player.position.x - transform.position.x) > Mathf.Abs(player.position.y - transform.position.y))
            {

                if (player.transform.position.x > transform.position.x)
                {
                    if (playerIsClose == true)
                    {
                        newanimation = "vikingattackRW";
                    }
                    else if (playerIsClose == false)
                    {
                        newanimation = "vikingwalkRW";
                    }
                }

                else
                {
                    if (playerIsClose == true)
                    {
                        newanimation = "vikingattackLV";
                    }
                    else if (playerIsClose == false)
                    {
                        newanimation = "vikingwalkLW";
                    }

                }
            }
            else
            {
                if (player.transform.position.y > transform.position.y)
                {
                    if (playerIsClose == true)
                    {
                        newanimation = "vikingattackBW";
                    }
                    else if (playerIsClose == false)
                    {
                        newanimation = "vikingwalkBW";
                    }
                }

                else
                {
                    if (playerIsClose == true)
                    {
                        newanimation = "vikingattackFW";
                    }
                    else if (playerIsClose == false)
                    {
                        newanimation = "vikingwalkFW";
                    }

                }
            }
        }

        else if (knockback.isknockedback == true)
        {
            knockback.Applyknockback();
        }

        if (newanimation != null && newanimation != currentanimation)
        {
            animator.Play(newanimation);
            currentanimation = newanimation;
        }


    }
}