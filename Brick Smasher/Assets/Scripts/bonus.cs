using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class bonus : MonoBehaviour
{
    private float randX;
    private float randY;
    private int wait = 5;
    private Vector2 position;
    public GameObject[] prefabs;
    private int randIndex;
   // private bool spwaned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnRate", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnRate()
    {
        if (bounceMovement.isGameStart && !bounceMovement.gameOver && !bounceMovement.gameStop)
        {
            randX = Random.Range(-6.92f, 7.05f);
            position = new Vector2(randX, 4.94f);
            randIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randIndex], position, Quaternion.identity);
        }
       
    }

   
}
