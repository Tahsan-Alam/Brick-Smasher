using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class bonus : MonoBehaviour
{
    private float randX;
    private Vector2 position;
    public GameObject[] prefabs;
    private int randIndex;
    private GameObject ball;
    private Rigidbody2D rb;
    //private bool spawned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindWithTag("Ball");
        InvokeRepeating(nameof(spawnRate), 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void spawnRate()
    {
        if (bounceMovement.isGameStart && !bounceMovement.gameOver && !bounceMovement.gameStop && !gameOptions.menuActive)
        {
            randX = Random.Range(-6.92f, 7.05f);
            position = new Vector2(ball.transform.position.x - 3, 4.94f);
            randIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randIndex], position, Quaternion.identity);
        }
               
    }


   
}
