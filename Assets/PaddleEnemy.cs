using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleEnemy : MonoBehaviour
{
    Ball ball;
    Vector3 pos;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if(pos.y <= ball.transform.position.y && pos.y <= 4.96)
        {
            transform.position = transform.position + new Vector3(0f, 0.1f, 0f);
        }
        else if (pos.y >= ball.transform.position.y && pos.y >= -5.03)
        {
            transform.position = transform.position + new Vector3(0f, -0.1f, 0f);
        }

        
    }
}
