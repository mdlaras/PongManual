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
    float lastx = 0;
    float lasty = 0;
    float posx;
    public float posy;
    int collidedOn = 5;
    float playerpos;
    float enemypos;
    PaddlePlayer player;
    PaddleEnemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.03f, 0.03f, 0);
        point1 = transform.position;
        player = FindObjectOfType<PaddlePlayer>();
        enemy = FindObjectOfType<PaddleEnemy>();
        playerpos = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        posx = transform.position.x;
        posy = transform.position.y;
        playerpos = player.transform.position.y;
        enemypos = enemy.transform.position.y;
        if (posy <= -5.03f)
        { 
            collidedOn = 1;
            Debug.Log(collidedOn);
            point2 = transform.position;
            mag = Vector3.Distance(point2, point1);
            unitvec = (point2 - point1);
            Vector3.Normalize(unitvec);
            Debug.Log(unitvec);
            lastx = transform.position.x;
            lasty = transform.position.y;
            point1 = point2;
        }
        if (posy >= 4.96f)
        {
            
            collidedOn = 2;
            Debug.Log(collidedOn);
            point2 = transform.position;
            mag = Vector3.Distance(point2, point1);
            unitvec = (point2 - point1);
            Vector3.Normalize(unitvec);
            Debug.Log(unitvec);
            lastx = transform.position.x;
            lasty = transform.position.y;
            point1 = point2;
        }
        if ((posx <= -8.87) || ((posx <= -6.96) && ((posy <= playerpos + 3f) && (posy >= playerpos - 3f))))
        {
            
            collidedOn = 3;
            Debug.Log(collidedOn);
            point2 = transform.position;
            mag = Vector3.Distance(point2, point1);
            unitvec = (point2 - point1);
            Vector3.Normalize(unitvec);
            Debug.Log(unitvec);
            lastx = transform.position.x;
            lasty = transform.position.y;
            point1 = point2;
        }
        if ((posx >= 8.96) || ((posx >= 7.12) && ((posy <= enemypos + 3f) && (posy >= enemypos - 3f))))
        {
           
            collidedOn = 4;
            Debug.Log(collidedOn);
            point2 = transform.position;
            mag = Vector3.Distance(point2, point1);
            unitvec = (point2 - point1);
            Vector3.Normalize(unitvec);
            Debug.Log(unitvec);
            lastx = transform.position.x;
            lasty = transform.position.y;
            point1 = point2;
        };
        
        if (unitvec.Equals(new Vector3(0, 0, 0)))
        {
            
            unitvec = new Vector3(20f, 20f, 0);
            if (collidedOn == 3)
            {
                unitvec = new Vector3(-20f, 20f, 0);
            }
            else if (collidedOn == 1)
            {
                unitvec = new Vector3(20f, -40f, 0);
            }
            else if (collidedOn == 2){
                unitvec = new Vector3(20f, 40f, 0);
            }
            Vector3.Normalize(unitvec);

        }
        switch (collidedOn)
        {
            case 1:
                transform.position = transform.position + Vector3.Reflect(unitvec, new Vector3(0f,1f,0f)) * 0.003f;
                break;
            case 2:
                transform.position = transform.position + Vector3.Reflect(unitvec, new Vector3(0f, -1f, 0f)) * 0.003f;
                break;
            case 3:
                transform.position = transform.position + Vector3.Reflect(unitvec, new Vector3(-1f, 0f, 0f)) * 0.003f;
                break; 
            case 4:
                transform.position = transform.position + Vector3.Reflect(unitvec, new Vector3(1f, 0f, 0f)) * 0.003f;
                break;
            case 5:
                transform.position = transform.position - new Vector3(0.03f, 0.03f, 0);
                break;
        }

        

        
        

    }
}
