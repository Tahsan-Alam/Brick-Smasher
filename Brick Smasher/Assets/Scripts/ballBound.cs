using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ballBound : MonoBehaviour
{
    public static float height = -3.73f;
    private float startPos = -3.05f;
    private GameObject player = GameObject.FindWithTag("Player");
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < height)
        {
            transform.position = new Vector2(0,startPos);
            player.transform.position = new Vector2(0.05f, -3.32f);
        }
    }
}
