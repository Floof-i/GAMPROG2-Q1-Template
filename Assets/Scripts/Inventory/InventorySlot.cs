using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemData itemData;
    public Image itemIcon;

    public void SetItem(ItemData data)
    {
        Debug.Log("Set " + data.id);
        itemIcon.enabled = true;
        itemData = data;
        itemIcon.sprite = data.icon;
        // TODO[DONE]
        // Set the item data the and icons here
    }

    public void UseItem()
    {     
        if(itemData != null)
        {
            if(itemData.type == ItemType.Unusable)
            {
                Debug.Log("Item is not usable!");
            }
            else
            {
                InventoryManager.Instance.UseItem(itemData);
                itemIcon.enabled = false;
                itemData = null;
                itemIcon.sprite = null;
            }
        }
        // TODO [DONE]
        // Reset the item data and the icons here
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}
