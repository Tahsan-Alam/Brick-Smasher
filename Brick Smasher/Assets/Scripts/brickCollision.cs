using UnityEngine;
using TMPro;

public class brickCollision : MonoBehaviour
{
    private AudioSource brick;
    private AudioSource paddle;
    private AudioSource metal;
    public AudioClip brickSound;
    public AudioClip paddleSound;
    public AudioClip metalSound;
    private int smashNum = 0;
    public TextMeshProUGUI smash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        brick = GetComponent<AudioSource>();
        paddle = GetComponent<AudioSource>();
        metal = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            smashNum += 1;
            smash.text = "Smash ->" + smashNum;
            brick.PlayOneShot(brickSound, 1.0f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (bounceMovement.isGameStart)
            {
                paddle.PlayOneShot(paddleSound, 1.0f);
            }
           
        }

        if (collision.gameObject.CompareTag("Border"))
        {
           metal.PlayOneShot(metalSound, 1.0f);
        }
    }

}
