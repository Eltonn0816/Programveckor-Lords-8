using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  
    public float damageTaken = 40f; 

    // This method will be called when the enemy is hit
    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            Die();  // Call the die method if health reaches 0
        }
    }

    void Die()
    {
        Destroy(gameObject);  // Trigger death animation first
    }
}

