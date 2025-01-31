using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercombat : MonoBehaviour
{
    public BoxCollider2D attackHitbox;
    public float attackDuration = 0.5f;
    public AudioSource audioSource;
    public float attackStart = 0.4f;
    private bool isAttacking = false;
    Animator animator;
   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attackHitbox.enabled = false;
        audioSource.mute = true;

    }

    // Update is called once per frame
    void Update()
    {

        UpdateHitboxRotation(); // Update hitbox direction

        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking) // Attack key
        {
            StartCoroutine(PerformAttack());
            audioSource.mute = false;

        }
    }


    private IEnumerator PerformAttack()
    {
        isAttacking = true; // Mark as attacking
        yield return new WaitForSeconds(attackStart);
        attackHitbox.enabled = true; // Enable the hitbox

        yield return new WaitForSeconds(attackDuration); // Wait for the attack duration

        attackHitbox.enabled = false; // Disable the hitbox
        isAttacking = false; // Reset attacking state
        audioSource.mute = true;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (attackHitbox.enabled && collision.CompareTag("Enemy"))
        {
          
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(35);
                isAttacking = false;
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
