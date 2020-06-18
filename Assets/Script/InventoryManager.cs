using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public string playerItem { private set; get; }
    [SerializeField]
    private InventoryUI inventoryUI;

    public void AddItemToInventory(string itemName) 
    {
        playerItem = itemName;
        Debug.Log("Item --- " + itemName + " added");
    }

    public GameObject RemoveItemOnInventory() 
    {
        GameObject itemPrefab = Resources.Load("prefabs/" + playerItem) as GameObject;
        playerItem = "";
        inventoryUI.RemoveImage();
        return itemPrefab;
    }

   
}
