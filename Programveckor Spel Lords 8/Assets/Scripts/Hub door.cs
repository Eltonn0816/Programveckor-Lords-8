using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enterdoorscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1); //�ndra scene nummer till level 1 n�r vi har den 
        }
            
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
