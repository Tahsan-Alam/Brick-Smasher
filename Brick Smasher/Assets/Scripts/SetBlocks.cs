using UnityEngine;
using UnityEngine.Rendering;

public class SetBlocks : MonoBehaviour
{
    public GameObject set1;
    public GameObject set2;
    public GameObject set3;
    public GameObject ball;
    private Rigidbody2D rb;
    private bool stop;
    public GameObject player;
    public static bool gameWin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        gameWin = false;
    }
    void Start()
    {
        stop = false;
        set1.SetActive(true);
        set2.SetActive(false);
        set3.SetActive(false);
        rb = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bounceMovement.gameOver == false)
        {
            if(set2 != null)
            {
                if (set1 == null && !set2.activeInHierarchy && !set3.activeInHierarchy)
                {
                    rb.bodyType = RigidbodyType2D.Static;
                    set2.SetActive(true);
                    stop = true;
                }
            }
            
            if (stop)
            {
                rb.bodyType= RigidbodyType2D.Dynamic;
                ball.transform.position = new Vector2(0, -2.601f);
                player.transform.position = new Vector2(0.05f, -2.86f);
                ball.transform.SetParent(player.transform);
                rb.linearVelocity = Vector3.zero;
                bounceMovement.isGameStart = false;
                stop = false;
            }

            if(set3 != null)
            {
                if (set1 == null && set2 == null && !set3.activeInHierarchy)
                {
                    rb.bodyType = RigidbodyType2D.Static;
                    set3.SetActive(true);
                    stop = true;
                }
            }
            if(set3 == null)
            {
                gameWin = true;
            }
           

        }


    }
}
