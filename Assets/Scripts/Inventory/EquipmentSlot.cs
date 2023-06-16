using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image defaultIcon;
    [SerializeField] private Image itemIcon;
    public EquipmentSlotType type;

    private ItemData itemData;

    public void SetItem(ItemData data)
    {
        Debug.Log("Equipped!");
        itemIcon.enabled = true;
        defaultIcon.enabled = false;
        itemData = data;
        itemIcon.sprite = data.icon;

        InventoryManager.Instance.player.AddAttributes(data.attributes);

        // TODO [DONE]
        // Set the item data the and icons here
        // Make sure to apply the attributes once an item is equipped
    }

    public void Unequip()
    {
        if(itemData != null)
        {
            bool result = InventoryManager.Instance.AddItem(itemData.id);
            if (result == true)
            {
                Debug.Log("There is free slot, item unequipped.");
                InventoryManager.Instance.player.RemoveAttributes(itemData.attributes);

                itemIcon.enabled = false;
                defaultIcon.enabled = true;
                itemData = null;
                itemIcon.sprite = null;
            }
            else
            {
                Debug.Log("No free slot, item not added.");
            }
        }
    
        // TODO
        // Check if there is an available inventory slot before removing the item.
        // Make sure to return the equipment to the inventory when there is an available slot.
        // Reset the item data and icons here
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}
