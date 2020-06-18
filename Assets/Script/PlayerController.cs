using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    public Collider2D collisionDetector;
    public SetDirection eyePosition;
    public float speed;
    public float speedMultiplier = 1;

    public ItemFunction itemFunction;

    private void FixedUpdate()
    {
        Vector3 coordinate = new Vector3();
        coordinate.x = Input.GetAxisRaw("Horizontal");
        coordinate.y = Input.GetAxisRaw("Vertical");
        transform.position = transform.position + coordinate * speed * Time.deltaTime * speedMultiplier;
        eyePosition.AdjustDirection(coordinate);
        if (itemFunction.PlayerCheckInventory()) 
        {
            if (Input.GetKeyDown("x")) // TODO find a way to improve the controls
            {
                itemFunction.PlayerPlace();
            }

            else if (Input.GetKeyDown("space")) 
            {
                gameObject.SetActive(true);
            }

            else if (Input.GetKeyDown("y"))
            {
                itemFunction.PlayerThrow();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            speedMultiplier = 0.50f;       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            speedMultiplier = 1.0f;
        }
    }
}
