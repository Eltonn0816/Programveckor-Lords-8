using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interactTextscript : MonoBehaviour
{
    //public GameObject dialogePanel;
    public TextMeshProUGUI interactText;
    private bool IsPlayerClose = false;
    // Start is called before the first frame update
    void Start()
    {
        if (interactText != null)
        {
            interactText.SetActive(false);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerClose = true;
            if (interactText != null)
            {
                interactText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerClose = false;
            if (interactText != null)
            {
                interactText.SetActive(false);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
