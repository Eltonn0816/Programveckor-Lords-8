using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 20f;  // Damage dealt by the player's attack
    public float attackRange = 1f;    // Range of the attack
    public LayerMask enemyLayer;      // The layer for enemy objects

    private void Update()
    {
        // Trigger attack when pressing the left mouse button (or another key)
        if (Input.GetMouseButtonDown(0))  // Left-click to attack
        {
            Attack();
        }
    }

    void Attack()
    {
        // Cast a ray or perform a collider check to detect nearby enemies
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (var enemy in enemiesHit)
        {
            // Check if the enemy has the EnemyHealth component
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage); // Apply damage to the enemy
            }
        }

        // Optionally: Add attack animation or sound effects here
    }

    // Visualize the attack range (optional for debugging)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

