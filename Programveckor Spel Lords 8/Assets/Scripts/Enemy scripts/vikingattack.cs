using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vikingattack : MonoBehaviour
{
    public bool playerIsClose;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {

            }

        }
    }
}
