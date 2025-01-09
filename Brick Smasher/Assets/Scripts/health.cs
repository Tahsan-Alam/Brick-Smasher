using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    public static bool healthUp;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthUp = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (bounceMovement.gameStop)
        {
            Destroy(gameObject);
        }

        if (gameOptions.menuActive)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        if (gameOptions.menuActive == false)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && bounceMovement.isGameStart)
        {
            healthUp = true;
            Destroy(gameObject);
 
        }
    }
}
