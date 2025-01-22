using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1door : MonoBehaviour
{
    
    public string sceneToLoad;
    public Sprite chaindDoorSprite;
    public Sprite openDoorSprite; 

    private SpriteRenderer spriteRenderer;
    public bool playerIsClose;
    private bool isDoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UptadeDoorState();

    }

    // Update is called once per frame
    void Update()
    {
       if(!isDoorOpen && EnemiesRemaining() == 0)
        {
            isDoorOpen = true;
            UptadeDoorState();
        }


        if (playerIsClose && isDoorOpen && Input.GetKeyDown(KeyCode.E))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
    private int EnemiesRemaining()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length; 
    }

    private void UptadeDoorState()
    {
        if (!isDoorOpen)
        {
            if (chaindDoorSprite != null)
            {
                spriteRenderer.sprite = chaindDoorSprite; 
            }
           
            GetComponent<Collider2D>().enabled = false;

        } 
        else
        {
          if(openDoorSprite != null)
            {
                spriteRenderer.sprite = openDoorSprite;
            }

            GetComponent<Collider2D>().enabled = true;
        }
        


    }

   
}
