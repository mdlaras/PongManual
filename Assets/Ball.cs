using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 unitvec;
    Vector3 point1;
    Vector3 point2;
    float mag;
    float posx;
    public float posy;
    int collidedOn = 5;
    float offset = 2.5f;
    float ballVelocity;
    [SerializeField] PaddlePlayer player;
    [SerializeField] PaddleEnemy enemy;
    [SerializeField] Rigidbody2D WallTop;
    [SerializeField] Rigidbody2D WallBottom;
    [SerializeField] Rigidbody2D WallRight;
    [SerializeField] Rigidbody2D WallLeft;

    void Collide()
    {
        Debug.Log(collidedOn);
        point2 = transform.position;
        mag = Vector3.Distance(point2, point1);
        unitvec = (point2 - point1) / mag;
        Debug.Log(unitvec);
        point1 = point2;
    }
    // Start is called before the first frame update
    void Start()
    {
        ballVelocity = 5f;
        transform.position = new Vector3(0.03f, 0.03f, 0);
        point1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posx = transform.position.x;
        posy = transform.position.y;
        float playertopbound = player.transform.position.y + offset;
        float playerlowbound = player.transform.position.y - offset;
        float enemytopbound = enemy.transform.position.y + offset;
        float enemylowbound = enemy.transform.position.y - offset;
        if (posy <= WallBottom.transform.position.y)
        { 
            collidedOn = 1;
            Collide();
        }
        if (posy >= WallTop.transform.position.y)
        {
            collidedOn = 2;
            Collide();
        }
        if ((posx <= WallLeft.transform.position.x) || ((posx <= player.transform.position.x) && ((posy <=playertopbound) && (posy >= playerlowbound))))
        {
            collidedOn = 3;
            Collide();
        }
        if ((posx >= WallRight.transform.position.x) || ((posx >= enemy.transform.position.x) && ((posy <= enemytopbound) && (posy >=enemylowbound))))
        {
            collidedOn = 4;
            Collide();
        };

        switch (collidedOn)
        {
            case 1:
                transform.position = transform.position + Vector3.Reflect(unitvec, new Vector3(0f,1f,0f)) * ballVelocity * Time.deltaTime;
                break;
            case 2:
                transform.position = transform.position + Vector3.Reflect(unitvec, new Vector3(0f, -1f, 0f)) * ballVelocity * Time.deltaTime;
                break;
            case 3:
                transform.position = transform.position + Vector3.Reflect(unitvec, new Vector3(-1f, 0f, 0f)) * ballVelocity * Time.deltaTime;
                break; 
            case 4:
                transform.position = transform.position + Vector3.Reflect(unitvec, new Vector3(1f, 0f, 0f)) * ballVelocity * Time.deltaTime;
                break;
            case 5:
                transform.position = transform.position - new Vector3(1f, 1f, 0) * ballVelocity * Time.deltaTime;
                break;
        }

        

        
        

    }
}
