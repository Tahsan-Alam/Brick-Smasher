using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;


public class gameOptions : MonoBehaviour
{
    public Image escape;
    public Image gameOver;
    public static bool menuActive = false;
    private Rigidbody2D ballRigidBody;
    private int stopTime = 4;
    private int passedTime = 1;
    public TextMeshProUGUI timer;
    public Image gameWin;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {   
        menuActive = false;
        ballRigidBody = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();  
    }


    // Update is called once per frame
    void Update()
    {
        
        if (bounceMovement.gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (menuActive == true)
                {
                    StartCoroutine(pauseTime());  
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
            gameOver.gameObject.SetActive(true);
        }

        if (SetBlocks.gameWin)
        {
            ballRigidBody.bodyType = RigidbodyType2D.Static;
            Time.timeScale = 0;
            bounceMovement.gameOver = true;
            gameWin.gameObject.SetActive(true);
        }
       
    }

    public void restartDelay()
    {
        Invoke(nameof(restart), 0.5f);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    public void quitDelay()
    {
        Invoke(nameof(quit), 0.5f);
    }
    public void quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    private IEnumerator pauseTime()
    {
        Time.timeScale = 0; 
        timer.text = "1";   
        escape.gameObject.SetActive(false);
        while (passedTime < stopTime)
        {
            timer.text = "" + passedTime;
            yield return new WaitForSecondsRealtime(1.0f);
            passedTime++;
        }

        timer.text = ""; 
        Time.timeScale = 1;
        passedTime = 1;
        if (bounceMovement.isGameStart)
        {
            ballRigidBody.bodyType = RigidbodyType2D.Dynamic;
            
        }
        menuActive = false;
    }
    
}
