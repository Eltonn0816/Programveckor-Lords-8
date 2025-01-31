using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemyknockback : MonoBehaviour
{
    public float knockbackforce = 5f;
    public float knockbackduration = 0.2f;
    public bool isknockedback = false;
    private Vector2 knockbackdirection;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }
    public void Applyknockback(Vector2 attackerposition)
    {
        knockbackdirection = (transform.position - (Vector3)attackerposition).normalized;
        if(rb!= null)
        {
            isknockedback = true;
            rb.velocity = knockbackdirection * knockbackforce;
            Invoke(nameof(Endknockback), knockbackduration);
        }
    }

    void Endknockback()
    {
        isknockedback = false;
        rb.velocity = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
