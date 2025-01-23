using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;
    public Image fadePanel;
    public float fadeSpeed = 1.0f;

    private bool isFading = false;
    private bool isFadeIn = true;
    private string sceneToLoad;  // Store the scene to load after the fade-out

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the FadeManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Register to listen for scene loading
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unregister to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        if (fadePanel != null)
        {
            fadePanel.color = new Color(0, 0, 0, 1); // Start fully black
            StartFadeIn(); // Fade-in when the scene starts
        }
        else
        {
            Debug.LogError("Fade Panel is not assigned.");
        }
    }

    private void Update()
    {
        if (isFading)
        {
            float fadeAmount = fadeSpeed * Time.deltaTime;
            Color currentColor = fadePanel.color;

            if (isFadeIn)
            {
                currentColor.a -= fadeAmount;
                if (currentColor.a <= 0)
                {
                    currentColor.a = 0;
                    isFading = false; // Fade-in complete
                }
            }
            else
            {
                currentColor.a += fadeAmount;
                if (currentColor.a >= 1)
                {
                    currentColor.a = 1;
                    isFading = false; // Fade-out complete
                    StartCoroutine(LoadSceneAfterFade()); // Load the next scene
                }
            }

            fadePanel.color = currentColor;
        }
    }

    // Starts the fade-out effect and stores the scene to load after fade-out
    public void StartFadeOut(string sceneName)
    {
        sceneToLoad = sceneName;  // Store the scene name to load
        isFadeIn = false;
        isFading = true;
    }

    // Starts the fade in effect
    public void StartFadeIn()
    {
        isFadeIn = true;
        isFading = true;
    }

    // This coroutine ensures the scene is loaded after fade-out
    private IEnumerator LoadSceneAfterFade()
    {
        // Wait until the fade-out is complete
        yield return new WaitForSeconds(fadeSpeed);

        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }

    // Called when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Start the fade-in process when the new scene is loaded
        StartFadeIn();
    }
}
