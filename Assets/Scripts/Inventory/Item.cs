using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        // TODO: Add the item to the inventory. Make sure to destroy the prefab once the item is collected 
        Debug.Log("Interact activated!");
        bool result = InventoryManager.Instance.AddItem(this.id);
        if (result == true)
        {
            Debug.Log("There is free slot, item added.");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No free slot, item not added.");
        }
        
    }
}
