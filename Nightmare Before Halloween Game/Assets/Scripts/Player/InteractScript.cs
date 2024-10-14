using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    //This variables is for checking if we can interact with an object
    public bool canInteract;
    //This variable is for checking if we are currently interacting with an object
    public bool isInteracting;

    //This variable is for keeping track of what object we are looking at !
    public Collider InteractableObject;

    //this variable is for keeping track of what key we are assigning to be our interact button
    public KeyCode interactKeyCode;

    private void Update()
    {

        //Calls the DrawDetector method
        DrawDetector();
        //Create a var variable and set it to equal Interactable Object variable and do .GetComponent of The interface for interaction
        var Obj = InteractableObject.GetComponent<IInteractable>();

        if (Obj == null || InteractableObject == null)
        {
            return;
        }
        //If I press the Interact button DOWN and can interact with other objects
        if (Input.GetKeyDown(interactKeyCode) && canInteract)
        {
            //If I am interacting with an object the call on the IInteractable Interact Method
            isInteracting = true;
            if (isInteracting)
            {
                Obj.Interact();
                isInteracting = false;  
            }

        }
    }

    //A custom method created for detecting Interacatable objects
    public void DrawDetector()
    {
        //Create a Ray variable and have it start from the player, and facing forward
        Ray detector = new Ray(transform.position, transform.forward);

        //If my Raycast
        if (Physics.Raycast(detector, out RaycastHit hit))
        {
            InteractableObject = hit.collider;

            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.forward);
    }

}
