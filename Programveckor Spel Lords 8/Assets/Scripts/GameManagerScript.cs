using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour
{

    public static GameManagerScript Instance;

    private bool hasWon = false;
    // Store whether each door has been used
    public Dictionary<string, bool> usedDoors = new Dictionary<string, bool>();
    private int doorsPassed = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Initiera usedDoors om den är tom
            if (usedDoors == null || usedDoors.Count == 0)
            {
                usedDoors = new Dictionary<string, bool>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void RegisterDoorUse(string doorID)
    {
        if (hasWon) return;
        if (!usedDoors.ContainsKey(doorID) || !usedDoors[doorID])
        {
            usedDoors[doorID] = true;
            doorsPassed++;
            Debug.Log($"Dörr {doorID} använd. Totalt antal använda dörrar: {doorsPassed}");
            if (doorsPassed >= 2) // Spelaren har gått igenom båda dörrarna
            {
                WinGame();
            }
        }
    }
    private void WinGame()
    {
        if (hasWon) return;
        hasWon = true;
        Debug.Log("du van! Laddar vinstscenen...");
        SceneManager.LoadScene("winscene");
        StartCoroutine(LoadVictoryScene());
    }
    private IEnumerator LoadVictoryScene()
    {
        yield return new WaitForSeconds(1f);  // Fördröjning för att undvika konflikter
        SceneManager.LoadScene("winscene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
