using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Player player;
    //For now, this will store information of the Items that can be added to the inventory
    public List<ItemData> itemDatabase;

    //Store all the inventory slots in the scene here
    public List<InventorySlot> inventorySlots;

    //Store all the equipment slots in the scene here
    public List<EquipmentSlot> equipmentSlots;

    //Singleton implementation. Do not change anything within this region.
    #region SingletonImplementation
    private static InventoryManager instance = null;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "Inventory";
                    instance = go.AddComponent<InventoryManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public bool UseItem(ItemData data)
    {
        if(data.type == ItemType.Consumable)
        {
            Debug.Log("Used " + data.id);
            InventoryManager.Instance.player.AddAttributes(data.attributes);
            return true;
        } 
        else if(data.type == ItemType.Equipable)
        {
            int index = GetEquipmentSlot(data.slotType);
            if(index > -1)
            {
                equipmentSlots[index].SetItem(data);
                return true;
            }
            else
            {
                Debug.Log("Slot is full!");
                return false;
            }
        }
    return false;
        // TODO[DONE]
        // If the item is a consumable, simply add the attributes of the item to the player.
        // If it is equippable, get the equipment slot that matches the item's slot.
        // Set the equipment slot's item as that of the used item
    }

   
    public bool AddItem(string itemID)
    {
        Debug.Log("Added " + itemID);
        foreach(ItemData item in itemDatabase)
        {
            if(item.id == itemID)
            {
                Debug.Log(itemID + " found in Database");

                int index = GetEmptyInventorySlot();

                if(index > -1)
                {
                    Debug.Log("Returned true!");
                    inventorySlots[index].SetItem(item);
                    return true;
                }
            }
        }
        Debug.Log("Returned false!");
        return false;
        //TODO [DONE]
        //1. Cycle through every item in the database until you find the item with the same id. DONE
        //2. Get the index of the InventorySlot that does not have any Item and set its Item to the Item found
    }

    public bool UseKey()
    {
        int index = DetectKeySlot();

        if (index > -1)
        {
            inventorySlots[index].RemoveItem();
            return true;
        }
        return false;
    }

    public int DetectKeySlot()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Debug.Log("Checking inventory slot " + i);
            if (inventorySlots[i].HasKey() == true)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetEmptyInventorySlot()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Debug.Log("Checking inventory slot " + i);
            InventorySlot slot = inventorySlots[i];
            if (slot.HasItem() == false)
            {
                Debug.Log("Returned!");
                return i;        
            }     
        }
        return -1;
        //TODO [DONE]
        //Check which inventory slot doesn't have an Item and return its index
    }

    public int GetEquipmentSlot(EquipmentSlotType type)
    {
        for (int i = 0; i < equipmentSlots.Count; i++)
        {
            Debug.Log("Checking equipment slot " + i);
            EquipmentSlot slot = equipmentSlots[i];

            if(equipmentSlots[i].type == type && slot.HasItem() == false)
            {
                Debug.Log("Found valid slot.");
                return i;
            }
        }
        return -1;
        //TODO
        //Check which equipment slot matches the slot type and return its index
        
    }
}
