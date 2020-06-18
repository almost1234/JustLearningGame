using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorProperties : MonoBehaviour
{
    float alteredSpeed = 2;
    //Apparently trigger is made by someone who moved, not the opposite. As such, implementing such event may not work
    //Maybe add dataStatus to alter the speed is a better idea

    //This is a poor way to implement trap tiles but it will do for now
    //Need to find a way to save all these things on a parent idk?
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SPEED LOWERED VIA CONTACT");
        if (collision.gameObject.tag == "Player") 
        {
            float playerSpeedData = collision.GetComponent<PlayerController>().speed;
            normalSpeed = playerSpeedData;
            playerSpeedData = normalSpeed / 4;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float playerSpeedData = collision.GetComponent<PlayerController>().speed;
            playerSpeedData = normalSpeed;
        }
    }
    */

}
