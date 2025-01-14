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
}
