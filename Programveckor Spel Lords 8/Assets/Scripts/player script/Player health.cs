using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.Rendering;

public class PlayerHP : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public Slider healthBar; 
    void Start()
    {
        currenthealth = maxhealth;
        
        if (healthBar != null)
        {
            healthBar.maxValue = maxhealth;
            healthBar.value = Mathf.Round(currenthealth);
        }
    }
    public void Takedamage (int damage = 20)
    {
        currenthealth -= damage;
        currenthealth = Mathf.Clamp(currenthealth, 0, maxhealth);
       
        if(healthBar != null)
        { healthBar.value = currenthealth; }
        if (currenthealth <= 0)
        {
            gameover();
        }
        void gameover() { SceneManager.LoadScene(1); }

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
         Takedamage();
        }
    }

}

