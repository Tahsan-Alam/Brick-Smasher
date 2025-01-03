using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameOptions : MonoBehaviour
{
    public Image escape;
   // public Canvas canvas;
    private bool menuActive = false;
    public TextMeshProUGUI header;
    private Rigidbody2D ballRigidBody;
    private GameObject ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {   
        ballRigidBody = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(bounceMovement.gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuActive == true)
                {
                    Time.timeScale = 1;
                    
                    
                    if(bounceMovement.isGameStart)
                    {
                        ballRigidBody.bodyType = RigidbodyType2D.Dynamic;
                    }
                    
                    escape.gameObject.SetActive(false);
                    menuActive = false;
                }
                else
                {
                    Time.timeScale = 0;
                    
                    if(bounceMovement.isGameStart)
                    {
                        ballRigidBody.bodyType = RigidbodyType2D.Static;
                    }
                    
                    escape.gameObject.SetActive(true);
                    menuActive = true;
                }

            }
        }
        else
        {
            escape.gameObject.SetActive(true);
            header.text = "Game Over";
        }
       
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    } 
}
