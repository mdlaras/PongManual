using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePlayer : MonoBehaviour
{
    float currentVelocity;
    [SerializeField] float paddleVelocity;

    // Start is called before the first frame update
    void Start()
    {
        currentVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentVelocity = paddleVelocity;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
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
