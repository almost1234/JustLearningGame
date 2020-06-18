using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProperties : MonoBehaviour
{
    // Start is called before the first frame update
    public int durabilityValue;
    public string itemName;

    public itemProperties item;

    public bool throwState;

    public AudioSource soundPlayer;
    public Sprite breakImage;
    public SpriteRenderer baseImage;


    public void Awake()
    {
        throwState = false;
        item = new itemProperties(durabilityValue, itemName);
    }
    public void Durability()
    {
        durabilityValue -= 1;
        Debug.Log("The durability is " + durabilityValue.ToString());
        if (durabilityValue == 0)
        {
            itemBreak();
        }

    }

    public void ChangeState() 
    {
        throwState = !throwState;
        Debug.Log("THE STATE NOW IS " + throwState);
    }

    public void FixedUpdate()
    {
        if (throwState == true)
        {
            //TODO Improve ways/ function to reference the player direction
            transform.position += new Vector3(0, 3 * Time.deltaTime, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("The name of the collision is " + collision.tag);
        if (collision.gameObject.tag == "Player")
        {
            Durability();
        }

        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            if (throwState == true)
            {
                itemBreak();
            }

        }

    }

    public void itemBreak() 
    {
        GameObject tiles = Resources.Load<GameObject>("Prefabs/" + itemName + "Break");
        GameObject tileGenerated = Instantiate(tiles);
        tileGenerated.transform.position = gameObject.transform.position;
        soundPlayer.Play();
        Destroy(gameObject);
    }
}

public struct itemProperties
{
    public int durabilityValue;
    public string itemName;

    public itemProperties(int durabilityValue, string itemName) 
    {
        this.durabilityValue = durabilityValue;
        this.itemName = itemName;
    }
}


