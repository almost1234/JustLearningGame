using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirection : MonoBehaviour
{

    public Transform positionTracker;
    public GameObject player;
    public ItemFunction itemFunction;
    public void AdjustDirection(Vector2 coordinate)
    {
        if (coordinate.x == 0 && coordinate.y == 0)
        {
            return;
        }
        positionTracker.localPosition = coordinate * 5;
    }

    public void OnTriggerStay2D(Collider2D collision) // there are some slight loose?
    {
        if (Input.GetKeyDown("space"))
        {
            switch (collision.tag)
            {
                case "Item":
                    itemFunction.PlayerPickUpItem(collision.gameObject);
                    break;
                case "Cover":
                    //TODO play some animation that simulates hiding
                    player.SetActive(false);
                    break;
            }
        }

    }
}
