using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class LazyFunction : MonoBehaviour
{
    public GameObject player;

    public void FixedUpdate()
    {
        if (Input.GetKeyDown("space")) 
        {
            if (player.activeSelf == false) 
            {
                player.SetActive(true);
            }
        }
    }
}
