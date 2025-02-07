using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyknockback : MonoBehaviour
{
    public Transform player;
    public float knockbackforce = 5f;
    public float knockbackduration = 0.2f;
    public bool isknockedback = false;
    public Vector3 knockbackdirection;
    private Rigidbody2D rb;
    public Aggressive vikingscript;
    public EnemyHealth ehealth;
    public Aggressive viking; 
    

    // Start is called before the first frame update
    void Start()
    {
        viking = GetComponent<Aggressive>();
        ehealth = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody2D>();
        vikingscript = GetComponent<Aggressive>();
    }
    
    void Update()
    {
        //attackerposition = player.position;
        
    }
    public void Applyknockback()
    {
        print("knockback applied");
        isknockedback = true;
        knockbackdirection = (transform.position - player.position).normalized;
        rb.velocity = knockbackdirection * knockbackforce;
     
        Invoke(nameof(Endknockback), knockbackduration);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            //Applyknockback(player.position);
        }
    }
    public void Endknockback()
    {
        isknockedback = false;
        rb.velocity = Vector3.zero;
    }
    
   
}
