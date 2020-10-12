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
    float offset = 2.5f;
    float ballVelocity;
    [SerializeField] Transform player;
    [SerializeField] Transform enemy;
    [SerializeField] Transform WallTop;
    [SerializeField] Transform WallBottom;
    [SerializeField] Transform WallRight;
    [SerializeField] Transform WallLeft;

    void Collide(Vector3 ReflectionAngle)
    {
        point2 = transform.position;
        mag = Vector3.Distance(point2, point1);
        if (Mathf.Abs(mag) < 0.001)
        {
            unitvec = new Vector3(1, 1, 0);
        }
        else
        {
            unitvec = (point2 - point1) / mag;
        }
        point1 = point2;
        unitvec = Vector3.Reflect(unitvec, ReflectionAngle);
    }
    // Start is called before the first frame update
    void Start()
    {
        ballVelocity = 5f;
        unitvec = new Vector3(1, 1, 0);
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
            Collide(new Vector3(0f, 1f, 0f));
        }
        if (posy >= WallTop.position.y)
        {
            Collide(new Vector3(0f, -1f, 0f));
        }
        if ((posx <= WallLeft.position.x) || ((posx <= player.position.x) && ((posy <=playertopbound) && (posy >= playerlowbound))))
        {
            Collide(new Vector3(-1f, 0f, 0f));
        }
        if ((posx >= WallRight.position.x) || ((posx >= enemy.position.x) && ((posy <= enemytopbound) && (posy >=enemylowbound))))
        {
            Collide(new Vector3(1f, 0f, 0f));
        };


        transform.position = transform.position + unitvec * ballVelocity * Time.deltaTime;




    }
}
