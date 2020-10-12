using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleEnemy : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] float paddleYVelocity;
    [SerializeField] Rigidbody2D TopWall;
    [SerializeField] Rigidbody2D BottomWall;
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
        if(paddleCenter.y <= ball.transform.position.y - offset && paddleCenter.y <= TopWall.transform.position.y)
        {
            currentVelocity = paddleYVelocity;
        }
        else if (paddleCenter.y >= ball.transform.position.y + offset && paddleCenter.y >= BottomWall.transform.position.y)
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
