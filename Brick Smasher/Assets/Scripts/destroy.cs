using UnityEngine;

public class destroy : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
}
