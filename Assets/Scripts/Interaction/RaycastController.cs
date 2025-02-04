using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 2.0f;

    [SerializeField]
    //The layer that will determine what the raycast will hit
    LayerMask interactable;
    //The UI text component that will display the name of the interactable hit
    public TextMeshProUGUI interactionInfo;

    private bool interactableHover = false;

    private RaycastHit hit;

    // Update is called once per frame
    private void Update()
    {
        //TODO: Raycast [DONE]
        //1. Perform a raycast originating from the gameobject's position towards its forward direction.
        //   Make sure that the raycast will only hit the layer specified in the layermask
        //2. Check if the object hits any Interactable. If it does, show the interactionInfo and set its text
        //   to the id of the Interactable hit. If it doesn't hit any Interactable, simply disable the text
        //3. Make sure to interact with the Interactable only when the mouse button is pressed.

        interactableHover = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance, interactable);

        if(interactableHover)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.red);
            Debug.Log("Collided with interactable!");
            interactionInfo.enabled = true;

            if (hit.collider.tag == "Item")
            {
                Item item = hit.collider.GetComponent("Item") as Item;
                interactionInfo.text = "Interact with " + item.id;
            }
            else if(hit.collider.tag == "Door")
            {
                Door door = hit.collider.GetComponent("Door") as Door;
                interactionInfo.text = "Interact with " + door.id;
            }
            
            mouseInput();
        }
        else if(!interactableHover)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.green);
            Debug.Log("No interactable!");
            interactionInfo.enabled = false;
        }
    }

    private void mouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click!");
            if (hit.collider.tag == "Item")
            {
                Item item = hit.collider.GetComponent("Item") as Item;
                item.Interact();
            }
            else if(hit.collider.tag == "Door")
            {
                Door door = hit.collider.GetComponent("Door") as Door;
                door.Interact();
            } 
        }
    }
}