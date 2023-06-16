using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string id;
    public Sprite icon;
    public ItemType type;
    public EquipmentSlotType slotType;
    public List<Attribute> attributes;
}

public enum ItemType
{
    Consumable,
    Equipable,
    Unusable,
}

public enum EquipmentSlotType
{
    Head,
    Torso,
    Feet,
    Mainhand,
    Offhand,
    Nonequipment,
    // TODO [DONE]
    // Define other equipment slots here
}

[System.Serializable]
public class Attribute
{
    public AttributeType type;
    public float value;

    public Attribute(AttributeType type, float value)
    {
        this.type = type;
        this.value = value;
    }
}

public enum AttributeType
{
    HP,
    MP,
    STR,
    AGI,
    DEF,
    // TODO [DONE]
    // Add other attribute types here
}

