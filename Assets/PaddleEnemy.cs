using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleEnemy : MonoBehaviour
{
    [SerializeField] Transform ball;
    [SerializeField] float paddleYVelocity;
    [SerializeField] Transform TopWall;
    [SerializeField] Transform BottomWall;
    float offset = 3;
    float currentVelocity;
    Vector3 paddleCenter;

    // Start is called before the first frame update
    void Start()
    {
        currentVelocity = 0;
    }


    // Update is called once per frame
    void Update()
    {
        paddleCenter = transform.position;
        if(paddleCenter.y <= ball.position.y - offset && paddleCenter.y <= TopWall.position.y)
        {
            currentVelocity = paddleYVelocity;
        }
        else if (paddleCenter.y >= ball.position.y + offset && paddleCenter.y >= BottomWall.position.y)
        {
            currentVelocity = -paddleYVelocity;
        }
        else
        {
            currentVelocity = 0;
        }

        transform.position += new Vector3(0, currentVelocity, 0) * Time.deltaTime;

        
    }
}
