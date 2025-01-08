using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    public static bool healthUp; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bounceMovement.isGameStart)
        {
            Destroy(gameObject);
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
