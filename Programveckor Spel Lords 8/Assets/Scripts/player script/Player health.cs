using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public int playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = 10;
    }

    // Update is called once per frame
    void Update()
    { 
        if (playerhealth < 1)
        {
            SceneManager.LoadScene(2);

        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerhealth -= 2; 
        }
    }

}

