using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private Renderer renderer;
    private Collider collider;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }
    public override void Interact()
    {
        Debug.Log("Interact activated!");
        bool result = InventoryManager.Instance.UseKey();
        if (result == true)
        {
            Debug.Log("Key used!");
            renderer.enabled = false;
            collider.enabled = false;
        }
        else
        {
            Debug.Log("The door is locked! Find key!");
        }
    }
}