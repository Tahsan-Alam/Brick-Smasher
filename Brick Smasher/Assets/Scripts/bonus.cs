using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class bonus : MonoBehaviour
{
    private float randX1;
    private float randX2;
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
            if(transform.position.x - (-6.92) < (7.05 - transform.position.x))
            {
                randX = Random.Range(-6.92f, transform.position.x);
            }
            else if(transform.position.x - (-6.92) > (7.05 - transform.position.x))
            {
                randX = Random.Range(transform.position.x, 7.05f);
            }
          
            position = new Vector2(randX, 4.94f);
            randIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randIndex], position, Quaternion.identity);
        }
               
    }


   
}
