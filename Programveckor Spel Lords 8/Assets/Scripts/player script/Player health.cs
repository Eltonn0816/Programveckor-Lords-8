using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;


public class PlayerHP : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private ParticleSystem healingParticlesInstante;
    public ParticleSystem healingParticles;
    int healthFlaskLeft;
    public Image flaskImage;
    public Sprite fullFlaskSprite;
    public Sprite halfFlaskSprite;
    public Sprite lessFlaskSprite;
    public Sprite EmptyFlaskSprite;
    public AudioSource audioSource;
    public int maxhealth = 100;
    public int currenthealth;
    public Slider healthBar; 
    void Start()
    {
        healthFlaskLeft = 3; 
        currenthealth = maxhealth;
        audioSource.mute = true;
        if (healthBar != null)
        {
            healthBar.maxValue = maxhealth;
            healthBar.value = Mathf.Round(currenthealth);
        }

        uppdateFlaskSprite();
    }
    public void Takedamage (int damage = 20)
    {
        currenthealth -= damage;
        currenthealth = Mathf.Clamp(currenthealth, 0, maxhealth);
        StartCoroutine(FlashRed());

        if (healthBar != null)
        { healthBar.value = currenthealth; }
        if (currenthealth <= 0)
        {
            gameover();
        }
        void gameover() { SceneManager.LoadScene(1); }

    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        { healthBar.value = currenthealth; }
        if (Input.GetKeyDown(KeyCode.R) && healthFlaskLeft != 0)
        {
            healingParticlesInstante = Instantiate(healingParticles, transform.position, Quaternion.identity);
            healing();
            StartCoroutine(FlashGreen());
            audioSource.mute = false;
            Invoke("stopsound", 2);
        }

    }
    private void stopsound()
    {
        audioSource.mute = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
         Takedamage();
        }
    }

    void healing()
    {
        currenthealth += 40;
        currenthealth = Mathf.Clamp(currenthealth, 0, maxhealth);
        healthFlaskLeft -= 1;
        uppdateFlaskSprite();
    }

    void uppdateFlaskSprite()
    {
        if (flaskImage == null) return;

        switch (healthFlaskLeft)
        {
            case 3:
                flaskImage.sprite = fullFlaskSprite;
            break;

            case 2:
                 flaskImage.sprite = halfFlaskSprite;
            break;

            case 1:
                flaskImage.sprite = lessFlaskSprite;
            break;

            default:
            flaskImage.sprite = EmptyFlaskSprite;
            break; 

        }
    }
    IEnumerator FlashRed()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }
    IEnumerator FlashGreen()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }

}

