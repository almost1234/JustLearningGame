using Pathfinding;
using Pathfinding.Examples;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using Color = UnityEngine.Color;

public class PathingAI : MonoBehaviour
{
    public AIDestinationSetter destination;
    public Transform ghost;
    public Transform ghostEye;
    public Transform[] setPath;
    public Transform destinationNow;
    public int pathNumber = 4; //terrible
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
        Debug.DrawRay(ghostEye.position, (ghostEye.position - ghost.position), Color.red);
        RaycastHit2D hit = Physics2D.Raycast(ghostEye.position, (ghostEye.position - ghost.position), 30);
        if (hit == true) 
        {
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
            }

            Debug.Log("The enemy attention span is " + attentionSpan.ToString());
        }

        
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        /*Fix the logic in between chasing the enemy a
        if (collision.gameObject.name == destinationNow.gameObject.name && followPath) 
        {
            destinationNow = ChooseClosestDestination();
            Debug.Log("The next target is " + destinationNow.name);
            ghost.Rotate(new Vector3(0, 0, -MathFormula.DotProductAngle(MathFormula.Vector3Converter(ghost.position), MathFormula.Vector3Converter(ghostEye.position), MathFormula.Vector3Converter(destinationNow.position))));
            destination.target = destinationNow;
            pathNumber += 1;
        }*/

        if (collision.gameObject.tag == "Pathing" ) 
        {
            pathNumber = ChooseClosestDestination();
            Debug.Log("The next target is " + pathNumber.ToString());
            ghost.Rotate(new Vector3(0, 0, -MathFormula.DotProductAngle(MathFormula.Vector3Converter(ghost.position), MathFormula.Vector3Converter(ghostEye.position), MathFormula.Vector3Converter(setPath[pathNumber % setPath.Length].position))));
            if (followPath && destinationNow.name == collision.name) 
            {
                destination.target = setPath[pathNumber % setPath.Length];
                destinationNow = setPath[pathNumber % setPath.Length];

            }
        }
    }

    public int ChooseClosestDestination() 
    {
        float point1 = MathFormula.DotProductAngle(MathFormula.Vector3Converter(ghost.position), MathFormula.Vector3Converter(ghostEye.position), MathFormula.Vector3Converter(setPath[(pathNumber + 1) % setPath.Length].position));
        float point2 = MathFormula.DotProductAngle(MathFormula.Vector3Converter(ghost.position), MathFormula.Vector3Converter(ghostEye.position), MathFormula.Vector3Converter(setPath[(pathNumber + -1) % setPath.Length].position));
        if (point1 < point2)
        {
            return pathNumber + 1;
        }

        else 
        {
            return pathNumber - 1;
        }
    }
    
    public void SeenPlayer(RaycastHit2D hit) 
    {
        destination.target = hit.transform;
        followPath = false;
        attack.DecreaseSanity(5);
        attack.enemyFollow = true;
        Debug.Log("ENEMY FOLLOWING UR ASS NOW");
    }
}
