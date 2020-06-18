using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDetection : MonoBehaviour
{
    public Transform eyeSensor;
    public Transform player;
    public Transform enemy;
    public Rigidbody2D rotationControl;
    public RaycastHit2D collide;
    private bool foundPlayer;
    public float range;
    
    void Start()
    {
        Rigidbody2D rotationControl = gameObject.GetComponent<Rigidbody2D>();
        foundPlayer = false;
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (foundPlayer == false)
        {
            Debug.Log("SOMETHING");
            rayCastPractice();
        }
        else 
        {
            angleAdjuster();
        }
        
    }
    void Update()
    {
        
    }
    void rayCastPractice() 
    {
        Vector3 endPoint = eyeSensor.position - enemy.position;
        RaycastHit2D collide = Physics2D.Raycast(eyeSensor.position,endPoint.normalized , range);
        Debug.DrawRay(eyeSensor.position, endPoint.normalized * range, Color.green);
        Debug.Log("casting");
        if (collide.collider != null)
        {
            Debug.Log(collide.transform.tag);
            foundPlayer = true;
        }
        else 
        {
            
            rotationControl.rotation += 0.1f;
        }

    }
    public void angleAdjuster() 
    {
        Vector3 playerVector = player.position - enemy.position;
        float angleCalculated = Mathf.Atan2(playerVector.y, playerVector.x) * Mathf.Rad2Deg;
        rotationControl.rotation = angleCalculated;
        enemy.position = enemy.position + (playerVector.normalized * Time.deltaTime);
        /*
        Vector3 leftVector = enemy.position + leftSensor.position;
        Vector3 rightVector = rightSensor.position + enemy.position;
        Debug.Log("player" + playerVector);
        Debug.Log("left" + leftVector);
        Debug.Log("right" + rightVector);
        if (Mathf.RoundToInt(Mathf.Atan2(leftVector.y, leftVector.x) * Mathf.Rad2Deg) != Mathf.RoundToInt(Mathf.Atan2(rightVector.y, rightVector.x) * Mathf.Rad2Deg)) 
        {
            rotationControl.rotation += 0.1f;
            Debug.Log("rotation now =" + rotationControl.rotation);
        }
        */

    }
}
