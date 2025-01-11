using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void startGameDelay()
    {
        Invoke(nameof(startGame), 0.5f);
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGameDelay()
    {
        Invoke(nameof(exitGame), 0.5f);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
