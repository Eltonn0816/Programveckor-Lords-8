using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //particles when enemy get hit 
    public ParticleSystem damagaParticles;
    public enemyknockback knockback; 
    public float health = 100f;  
    public float damageTaken = 35f;
    private ParticleSystem damageParticlesInstance;
    public Transform player; 
    

    // This method will be called when the enemy is hit
    private void Start()
    {
        knockback = GetComponent<enemyknockback>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        spawnDamagaParticles();
        knockback.Applyknockback();
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
        if (health < 1)
        {
            Die();  // Call the die method if health reaches 0
        }
    }
    void Die()
    {
        Destroy(gameObject);  // Trigger death animation first
    }

    private void spawnDamagaParticles()
    {
        damageParticlesInstance = Instantiate(damagaParticles, transform.position, Quaternion.identity);
    }

}

