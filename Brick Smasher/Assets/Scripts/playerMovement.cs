using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed = 20f;
    private float movement;
    private float left = -6.472f;
    private float right = 6.642f;
    private GameObject ball;
    private Vector3 newScale;
    private float scaleY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindWithTag("Ball");
        newScale = transform.localScale;
        scaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(bounceMovement.gameOver == false)
        {
            if (bounceMovement.isGameStart == false)
            {
                ball.transform.SetParent(transform);
            }
            if (bounceMovement.gameStop == false)
            {
                movement = Input.GetAxis("Horizontal");
            }
            transform.Translate(movement * speed * Time.deltaTime * -Vector2.up);
            if (transform.position.x < left)
            {
                transform.position = new Vector2(left, transform.position.y);
            }
            if (transform.position.x > right)
            {
                transform.position = new Vector2(right, transform.position.y);
            }

            if (bounceMovement.isGameStart && ball.transform.parent == transform)
            {
                ball.transform.SetParent(null);
            }

            if (bounceMovement.gameStop)
            {
                newScale.y = scaleY;
                transform.localScale = newScale;
            }
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("long") && bounceMovement.isGameStart)
        {
            newScale.y = 0.126f;
            transform.localScale = newScale;
            Destroy(collision.gameObject);

        }

        if(collision.CompareTag("short")  && bounceMovement.isGameStart)
        {
            newScale.y = 0.0601f;
            transform.localScale = newScale;
            Destroy (collision.gameObject);
        }

    }
}
