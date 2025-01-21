using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enterdoorscript : MonoBehaviour
{

    public string doorID;
    public string sceneToLoad;
    public Sprite chaindDoorSprite;

    private SpriteRenderer spriteRenderer;
    private bool isDoorUsed;

    public bool playerIsClose;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (GameManagerScript.Instance.usedDoors.ContainsKey(doorID) && GameManagerScript.Instance.usedDoors[doorID])
        {
            isDoorUsed = true;
            UpdateDoorAppearance();

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && !isDoorUsed)
        {
            GameManagerScript.Instance.usedDoors[doorID] = true;
            SceneManager.LoadScene(sceneToLoad);
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

    private void UpdateDoorAppearance()
    {
        if (chaindDoorSprite != null)
        {
            spriteRenderer.sprite = chaindDoorSprite;
        }
        GetComponent<Collider2D>().enabled = false;
    }
}
