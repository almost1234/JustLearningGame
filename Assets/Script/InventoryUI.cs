using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image inventoryPicture;
    public GameObject inventory;

    public void SetImage(string itemName) 
    {
        string filePath = "Sprites/" + itemName;
        Debug.Log(filePath);
        Sprite imageSet = Resources.Load<Sprite>("Sprites/" + itemName);
        inventoryPicture.sprite = imageSet;
        inventory.SetActive(true);
        Debug.Log("Image set");
    }

    public void RemoveImage() 
    {
        inventory.SetActive(false);
    }
}
