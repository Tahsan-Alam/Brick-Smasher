using UnityEngine;

public class bomb : MonoBehaviour
{
    public static bool gameStop2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameStop2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bounceMovement.gameStop)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && bounceMovement.isGameStart)
        {
            gameStop2 = true;
            Time.timeScale = 0f;
            Destroy(gameObject);
            
        }
       
    }


}
