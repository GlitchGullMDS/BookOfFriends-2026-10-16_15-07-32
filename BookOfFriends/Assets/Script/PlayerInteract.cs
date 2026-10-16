using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable currentInteraction; //reference the current object through our interactable interface
    //Using an interface so I don't need to do a check on what object we're interacting with, the object ITSELF calls it.

    void Update()
    {
        if (currentInteraction != null && !Dialogue.IsActive && InputManager.InteractWasPressed)
        {
            currentInteraction.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteraction = interactable;
            //if not null, theres an object in range, which means we can allow the player to interact.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteraction) //if we put 2 interactables next to each other like idiots
        {
            currentInteraction = null;
        }
    }
}
