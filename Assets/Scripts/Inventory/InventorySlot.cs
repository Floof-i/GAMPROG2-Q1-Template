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

    public void RemoveItem()
    {
        itemIcon.enabled = false;
        itemData = null;
        itemIcon.sprite = null;
    }

    public void UseItem()
    {     
        if(itemData != null)
        {
            if(itemData.type == ItemType.Key)
            {
                Debug.Log("Item is not usable!");
            }
            else
            {
                bool result = InventoryManager.Instance.UseItem(itemData);
                if(result == true)
                {
                    itemIcon.enabled = false;
                    itemData = null;
                    itemIcon.sprite = null;
                }
            }
        }
        // TODO [DONE]
        // Reset the item data and the icons here
    }

    public bool HasKey()
    {
        if(HasItem() == true)
        {
            return itemData.type == ItemType.Key;
        }
        else
        {
            return false;
        }
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}
