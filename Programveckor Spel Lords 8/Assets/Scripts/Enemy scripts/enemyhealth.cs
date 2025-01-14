using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  
    public float damageTaken = 35f; 

    // This method will be called when the enemy is hit
    public void TakeDamage(float damage)
    {
        health -= damage; 
        if (health <= 1)
        {
            Die();  // Call the die method if health reaches 0
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Weapon"))
        {
            TakeDamage(damageTaken);
           
        } 
      
    }
    private void Update()
    {
        if (health <= 1)
        {
            Die();  // Call the die method if health reaches 0
        }
    }
    void Die()
    {
        Destroy(gameObject);  // Trigger death animation first
    }
}

