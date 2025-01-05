using UnityEngine;

public class bomb : MonoBehaviour
{
    public static bool gameStop2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameStop2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameStop2 = true;
            Destroy(gameObject);
        }
    }
}
