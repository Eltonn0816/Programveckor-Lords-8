using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderKeywordFilter;
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

    // Start is called before the first frame update
    void Start()
    {
        ehealth = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody2D>();
        vikingscript = GetComponent<Aggressive>();
    }
    
    void Update()
    {
        Vector3 attackerposition = player.position;
        knockbackdirection = (transform.position - player.position).normalized;  
    }
    public void Applyknockback(Vector3 attackerposition)
    {
        isknockedback = true;
        rb.velocity = knockbackdirection * knockbackforce;
        Invoke(nameof(Endknockback), knockbackduration);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Applyknockback(player.position);
        }
    }
    public void Endknockback()
    {
        isknockedback = false;
        rb.velocity = Vector3.zero;
    }
    
   
}
