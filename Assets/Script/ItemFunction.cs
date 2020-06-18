using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunction : MonoBehaviour
{
    public Transform playerDirection;
    public Transform itemParent;
    //The function is to facilitate the action a player want to do
    public InventoryManager inventoryManager;
    public InventoryUI inventoryUI;

    public bool PlayerCheckInventory()
    {
        if (inventoryManager.playerItem != null)
        {
            return true;
        }

        return false;
    }

    public GameObject PlayerPlace() 
    {
        GameObject itemRemoved = inventoryManager.RemoveItemOnInventory();
        Transform setItem = Instantiate(itemRemoved, itemParent).GetComponent<Transform>();
        //TODO Need to add if placable (Possibly via collision of playerDirection?)
        setItem.position = playerDirection.position;
        return itemRemoved;
    }

    public void PlayerThrow() 
    {
        GameObject itemRemoved = inventoryManager.RemoveItemOnInventory();
        GameObject setItem = Instantiate(itemRemoved, itemParent);
        //TODO Need to add if placable (Possibly via collision of playerDirection?)
        setItem.GetComponent<Transform>().position = playerDirection.position;
        setItem.GetComponent<BreakableProperties>().ChangeState();
        
    }

    public void PlayerPickUpItem(GameObject itemPickedUp) 
    {
        //TODO Improve the data transfer & functionality (Like save the whole struct idk)
        string itemName = itemPickedUp.GetComponent<BreakableProperties>().item.itemName;
        inventoryUI.SetImage(itemName);
        inventoryManager.AddItemToInventory(itemName);
        Destroy(itemPickedUp);
    }

    public void PlayerWalkOverTrap(GameObject floor) 
    {
        // is it really necessary?
    }
}
