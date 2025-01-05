using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;


/*
losing life audio source:
link: https://pixabay.com/sound-effects/game-fail-90322/
Artist: Leszek_Szary (Freesound)
Media type: MP3
Published date: August 18, 2022
License: Pixabay Content License
 */
public class bounceMovement : MonoBehaviour
{
    public static float speed = 13f;
    private float height = -3.73f;
    private Rigidbody2D rb;
    private GameObject player;

    public static bool isGameStart;
    private int health = 5;
    public TextMeshProUGUI healthText;
    public Image darkScreenImage;
    private Color color;

    private AudioSource lostHealth;
    private AudioSource game;
    public static bool gameStop;
    public static bool gameOver;

    public AudioClip healthLoss;
    public AudioClip gameOverSound;

    void Awake()
    {
        gameStop = false;
        isGameStart = false;
        gameOver = false;
        Time.timeScale = 1f;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        lostHealth = GetComponent<AudioSource>();
        game = GetComponent<AudioSource>();
       
        color = darkScreenImage.color;
        color.a = 0f;
        darkScreenImage.color = color;
    }


    private void Update()
    {
        if (gameOver == false)
        {
            if (transform.position.y < height && gameStop == false)
            {
                gameStop = true;
                StartCoroutine(afterDarkScreen());

            }
            if (Input.GetKeyDown(KeyCode.Space) && isGameStart == false)
            {
                rb.gravityScale = 0;
                rb.linearVelocity = new Vector2(0, 15f);
                isGameStart = true;
            }
          
            if (isGameStart)
            {
                rb.gravityScale = 1f;
                if (rb.linearVelocity.magnitude - speed > 2)
                {
                    rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, speed - 7f);
                }
                else if (rb.linearVelocity.magnitude > speed)
                {
                    rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, speed - 2f);
                }
                if (transform.position.x >= 7.33)
                {
                    rb.linearVelocity = new Vector2(2, 6.39f);
                }
                if (transform.position.x <= -7.16)
                {
                    rb.linearVelocity = new Vector2(2, -6.6f);
                }

            }
        } 
    }

    
    private IEnumerator darkScreenPanel()
    {
        color.a = 0.8f;
        darkScreenImage.color = color;
        lostHealth.PlayOneShot(healthLoss, 1.0f);
        yield return new WaitForSeconds(2.0f);
        color.a = 0f;
        darkScreenImage.color = color;
        gameStop = false;
       
        
    }

    private IEnumerator afterDarkScreen()
    {
       
        yield return StartCoroutine(darkScreenPanel());

        if(gameStop == false)
        {
            rb.gravityScale = 0;
            health -= 1;
            if (health == 0)
            {
                game.PlayOneShot(gameOverSound,1.0f);
                gameOver = true;
            }
            else
            {
                healthText.text = "" + health;
                transform.position = new Vector2(0, -2.601f);
                player.transform.position = new Vector2(0.05f, -2.86f);
                rb.linearVelocity = Vector3.zero;
                isGameStart = false;
            }
        }
    }


}
