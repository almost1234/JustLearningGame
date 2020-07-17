using JetBrains.Annotations;
using Pathfinding;
using Pathfinding.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Color = UnityEngine.Color;
using Vector2 = UnityEngine.Vector2;

public class PathingAI : MonoBehaviour //this shouldnt be pathingAI, the name is terrible
{
    public AIDestinationSetter destination;
    public Transform ghost;
    public Transform ghostEye;
    public Transform[] setPath;
    public Transform destinationNow;

    public AstarPath graph;
    public AIPath aiPath;

    public int pathNumber;
    public bool followPath = true;

    public PlayerSanity attack;
    public float attentionSpan = 5;

    public void Awake()
    {
        pathNumber = setPath.Length;
        destination.target = setPath[pathNumber % setPath.Length];

    }

    public void FixedUpdate()
    {
        rotateCharacter();
        Debug.DrawRay(ghostEye.position, (ghostEye.position - ghost.position), Color.red);
        RaycastHit2D hit = Physics2D.Raycast(ghostEye.position, (ghostEye.position - ghost.position), 30);
        if (hit == true) 
        {
            Debug.Log("It was hitting " + hit.collider.name);
            if (hit.collider.tag == "Player") 
            {
                SeenPlayer(hit);
                if (attack.enemyFollow) 
                {
                    attentionSpan = 5;
                }
            }
        }

        if (attack.enemyFollow) 
        {
            attentionSpan -= 1 * Time.deltaTime;
            if (attentionSpan < 0)
            {
                attack.enemyFollow = false;
                attentionSpan = 5;
                Debug.Log("Enemy stop following");
                destination.target = destinationNow;
                followPath = true;
            }

            Debug.Log("The enemy attention span is " + attentionSpan.ToString());
        }

        
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Pathing" ) 
        {
            Debug.Log("CHOOSING on transform " + Array.IndexOf(setPath, collision.transform).ToString());
            pathNumber = ChooseClosestDestination(Array.IndexOf(setPath, collision.transform) + setPath.Length);
            Debug.Log("The path number is " + pathNumber.ToString());
            /*Debug.Log("The next target is " + pathNumber.ToString());
            ghost.Rotate(new Vector3(0, 0, -MathFormula.DotProductAngle(MathFormula.Vector3Converter(ghost.position), MathFormula.Vector3Converter(ghostEye.position), MathFormula.Vector3Converter(setPath[pathNumber % setPath.Length].position))));*/
            if (followPath && destinationNow.name == collision.name) 
            {
                destination.target = setPath[pathNumber % setPath.Length];
                destinationNow = setPath[pathNumber % setPath.Length];
                graph.Scan(); // need to find a delegate/event to call this instead


            }
        }

        if (collision.gameObject.tag == "Item") 
        {
            //shouldnt die but yes
            gameObject.SetActive(false);
        }
    }

    public int ChooseClosestDestination(int pointNumber)
    {
        float point1 = MathFormula.DotProductAngle(MathFormula.Vector3Converter(ghost.position), MathFormula.Vector3Converter(ghostEye.position), MathFormula.Vector3Converter(setPath[(pointNumber + 1) % setPath.Length].position));
        float point2 = MathFormula.DotProductAngle(MathFormula.Vector3Converter(ghost.position), MathFormula.Vector3Converter(ghostEye.position), MathFormula.Vector3Converter(setPath[(pointNumber + -1) % setPath.Length].position));
        if (point1 < point2)
        {
            return pointNumber + 1;
        }

        else
        {
            return pointNumber - 1;
        }

    }

    public void rotateCharacter() //poor rotation implementation. The lookat only works in 3d but not in 2d
    {
        /*Debug.Log("X position desired velocity =" + aiPath.desiredVelocity.x);
        Debug.Log("y position desired velocity =" + aiPath.desiredVelocity.y);*/
        int eyePosition = 4;
        if (aiPath.desiredVelocity.x >= 1.5f)
        {
            ghostEye.localPosition = new Vector2(eyePosition , 0);
            return;
        }

        else if (aiPath.desiredVelocity.x <= -1.5f) 
        {
            ghostEye.localPosition = new Vector2(-eyePosition , 0);
            return;
        }

        if (aiPath.desiredVelocity.y >= 1.5f)
        {
            ghostEye.localPosition = new Vector2(0, eyePosition );
            return;
        }

        else if (aiPath.desiredVelocity.y <= -1.5f)
        {
            ghostEye.localPosition = new Vector2(0, -eyePosition );
            return;
        }
    }
    
    public void SeenPlayer(RaycastHit2D hit) //need to fix the data flow, maybe events?
    {
        destination.target = hit.transform;
        followPath = false;
        attack.DecreaseSanity(30);
        attack.enemyFollow = true;
    }
}
