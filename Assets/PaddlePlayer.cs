using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePlayer : MonoBehaviour
{
    public float posy;
    public Vector2 collisionArea;

    // Start is called before the first frame update
    void Start()
    {
        posy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            posy = posy +  0.00000001f;
            transform.position = transform.position + new Vector3(0f,posy*0.1f,0f);
            Debug.Log(transform.position.y);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            posy = posy + 0.00000001f;
            transform.position = transform.position + new Vector3(0f, -posy*0.1f, 0f);
            Debug.Log(transform.position.y);
        };
        collisionArea = new Vector2(posy + 10, posy - 10);
    }
}
