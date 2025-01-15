using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggressive : MonoBehaviour
{
    public Transform player;
    public float speed = 4f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        direction = direction.normalized * speed; 
        // if(player.transform.position.x > transform.position.x) { animator.Play("vikingwalkRW"); }
    }
}
