using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePlayer : MonoBehaviour
{
    float currentVelocity;
    [SerializeField] float paddleVelocity;
    [SerializeField] Rigidbody2D TopWall;
    [SerializeField] Rigidbody2D BottomWall;
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
        if (Input.GetKey(KeyCode.UpArrow) && paddleCenter.y <= TopWall.transform.position.y)
        {
            currentVelocity = paddleVelocity;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && paddleCenter.y >= BottomWall.transform.position.y)
        {
            currentVelocity = -paddleVelocity;
        }
        else
        {
            currentVelocity = 0;
        };

        transform.position += new Vector3(0, currentVelocity, 0) * Time.deltaTime;
    }
}
