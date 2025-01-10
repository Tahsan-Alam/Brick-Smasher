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
    private Rigidbody2D ballRb;

    public static bool isGameStart;
    public static int lives = 8;
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
        lives = 8;
        Time.timeScale = 1f;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        ballRb = GetComponent<Rigidbody2D>();

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
            if ((transform.position.y < height && gameStop == false) || bomb.gameStop2)
            {
                gameStop = true;
                bomb.gameStop2 = false;
                Time.timeScale = 0;
                ballRb.bodyType = RigidbodyType2D.Static;
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
                Time.timeScale = 1f;
                if(rb.bodyType == RigidbodyType2D.Dynamic)
                {
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
            if (health.healthUp)
            {
                lives += 1;
                healthText.text = "" + lives;
                health.healthUp = false;
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
            lives -= 1;
            if (lives == 0)
            {
                game.PlayOneShot(gameOverSound,1.0f);
                gameOver = true;
            }
            else
            {
                ballRb.bodyType = RigidbodyType2D.Dynamic;
                healthText.text = "" + lives;
                transform.position = new Vector2(0, -2.601f);
                player.transform.position = new Vector2(0.05f, -2.86f);
                rb.linearVelocity = Vector3.zero;
                isGameStart = false;
                
            }
        }
    }


}
