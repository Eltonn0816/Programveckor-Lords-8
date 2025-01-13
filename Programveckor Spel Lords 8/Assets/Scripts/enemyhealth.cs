using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  // Enemy's health
    public float damageTaken = 10f; // Default damage taken value for the enemy

    // This method will be called when the enemy is hit
    public void TakeDamage(float damage)
    {
        health -= damage; // Subtract the damage from the enemy's health
        Debug.Log($"{gameObject.name} took {damage} damage. Health remaining: {health}");

        if (health <= 0)
        {
            Die();  // Call the die method if health reaches 0
        }
    }

    void Die()
    {
        // Destroy the enemy when health reaches zero
        Debug.Log($"{gameObject.name} has died!");
        Destroy(gameObject);  // You can also trigger animations or effects here
    }
}

