using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class wizard : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialougeText;
    public string[] dialouge;
    private int index;

    public GameObject ePopUp;

    public GameObject continueButton;
    // speed with worlds will be read up.
    public float worldSpeed;
    //kollar hur n�ra spelaren �r.
    public bool playerIsClose;

   
    // Update is called once per frame
    void Update()
    {

        //om spelaren �r n�ra och trycker E kan man prata
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }


        }
        if ( dialougeText.text == dialouge[index])
        {
            continueButton.SetActive(true);

        }

        
    }

    public void zeroText()
    {

        dialougeText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialouge[index].ToCharArray())
        {
            dialougeText.text += letter;
            yield return new WaitForSeconds(worldSpeed);

        }
    }
    //n�sta r�d text 
    public void NextLine()
    {
        continueButton.SetActive(false);

        if (index < dialouge.Length - 1)
        {
            index++;
            dialougeText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }

    }
    //kollar om spelaren �r n�ra
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            ePopUp.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
            ePopUp.SetActive(false);
        }
    }

}
