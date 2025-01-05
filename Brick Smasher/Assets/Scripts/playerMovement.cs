using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed = 20f;
    private float movement;
    private float left = -6.472f;
    private float right = 6.642f;
    private GameObject ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindWithTag("Ball");
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
        }
      
    }
}
