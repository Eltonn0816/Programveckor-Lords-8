using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggresiveCaveMán : MonoBehaviour
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

            }
            else
            {
                if (player.transform.position.y > transform.position.y)
                {
                    if (playerIsClose == true)
                    {
                        newanimation = "cave man attack up";
                    }
                    else if (playerIsClose == false)
                    {
                        newanimation = "cave man walk up";
                    }
                }

                else
                {
                    if (playerIsClose == true)
                    {
                        newanimation = "cave man attack down";
                    }
                    else if (playerIsClose == false)
                    {
                        newanimation = "cave man walk down";
                    }

                }
            }
        }
        else if (knockback.isknockedback == true)
        {
            knockback.knockbackdirection = (transform.position - player.position).normalized;
            transform.position += movementdirection * speed * Time.deltaTime;
        }




        if (newanimation != null && newanimation != currentanimation)
        {
            animator.Play(newanimation);
            currentanimation = newanimation;
        }


    }
}