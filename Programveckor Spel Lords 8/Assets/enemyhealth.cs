using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    [SerializeField] float health, Maxhealth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
    }

    public void Takedamage(float damageamount)
    {
        health -= damageamount; // 3 -> 2 -> 1 -> 0 = enemy has died

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}