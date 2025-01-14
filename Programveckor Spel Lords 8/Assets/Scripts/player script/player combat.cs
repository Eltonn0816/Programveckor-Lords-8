using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercombat : MonoBehaviour
{
    public BoxCollider2D attackHitbox;
    public float attackDuration = 0.1f;

    private Vector2 rightPosition = new Vector2(1f, 0f); // Position when facing right
    private Vector2 leftPosition = new Vector2(-1f, 0f); // Position when facing left

    private bool isAttacking = false;
    Animator animator;
   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
        
     UpdateHitboxRotation(); // Update hitbox direction

     if (Input.GetKeyDown(KeyCode.Space)) // Attack key
     {
        StartCoroutine(PerformAttack());
     }
     

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PerformAttack());
        }
        UpdateHitboxPosition();
    }
    void UpdateHitboxPosition()
    {
        // Detect the player's facing direction
        float playerDirection = transform.localScale.x > 0 ? 1 : -1;
        attackHitbox.offset = playerDirection > 0 ? rightPosition : leftPosition;
    }

    System.Collections.IEnumerator PerformAttack()
    {
        isAttacking = true; //enables attacking
        attackHitbox.enabled = true; //enables hitbox
        yield return new WaitForSeconds(attackDuration); //waits for the attack duration
        attackHitbox.enabled = false; //disables hitbox
        isAttacking = false; //disables attacking
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (attackHitbox.enabled && collision.CompareTag("Enemy"))
        {
          
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(35);
            }
        }
    }

    void UpdateHitboxRotation()
    {
        Vector2 direction = Vector2.zero;

        // Determine facing direction
        if (Input.GetKey(KeyCode.W)) direction = Vector2.up;        // Up
        else if (Input.GetKey(KeyCode.S)) direction = Vector2.down; // Down
        else if (Input.GetKey(KeyCode.A)) direction = Vector2.left; // Left
        else if (Input.GetKey(KeyCode.D)) direction = Vector2.right; // Right

        // Update rotation
        if (direction == Vector2.up)
            attackHitbox.transform.rotation = Quaternion.Euler(0, 0, 90); // Up
        else if (direction == Vector2.down)
            attackHitbox.transform.rotation = Quaternion.Euler(0, 0, -90); // Down
        else if (direction == Vector2.left)
            attackHitbox.transform.rotation = Quaternion.Euler(0, 0, 180); // Left
        else if (direction == Vector2.right)
            attackHitbox.transform.rotation = Quaternion.Euler(0, 0, 0); // Right
    }

}
