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
    [SerializeField] Transform player;
    [SerializeField] Transform enemy;
    [SerializeField] Transform WallTop;
    [SerializeField] Transform WallBottom;
    [SerializeField] Transform WallRight;
    [SerializeField] Transform WallLeft;

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
        unitvec = Vector3.Normalize(new Vector3(0.03f, 0.03f, 0));
        point1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posx = transform.position.x;
        posy = transform.position.y;
        float playertopbound = player.position.y + offset;
        float playerlowbound = player.position.y - offset;
        float enemytopbound = enemy.position.y + offset;
        float enemylowbound = enemy.position.y - offset;
        if (posy <= WallBottom.position.y)
        { 
            collidedOn = 1;
            Collide();
            unitvec = Vector3.Reflect(unitvec, new Vector3(0f, 1f, 0f));
        }
        if (posy >= WallTop.position.y)
        {
            collidedOn = 2;
            Collide();
            unitvec = Vector3.Reflect(unitvec, new Vector3(0f, -1f, 0f));
        }
        if ((posx <= WallLeft.position.x) || ((posx <= player.position.x) && ((posy <=playertopbound) && (posy >= playerlowbound))))
        {
            collidedOn = 3;
            Collide();
            unitvec = Vector3.Reflect(unitvec, new Vector3(-1f, 0f, 0f));
        }
        if ((posx >= WallRight.position.x) || ((posx >= enemy.position.x) && ((posy <= enemytopbound) && (posy >=enemylowbound))))
        {
            collidedOn = 4;
            Collide();
            unitvec = Vector3.Reflect(unitvec, new Vector3(1f, 0f, 0f));
        };


        transform.position = transform.position + unitvec * ballVelocity * Time.deltaTime;




    }
}
