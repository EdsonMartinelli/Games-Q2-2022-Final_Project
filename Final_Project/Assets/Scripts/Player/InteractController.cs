using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : InputController
{
    public GameObject interactHint;
    private GameObject interactObj = null;
    private IInteractable interfaceObj = null;
    private bool isInInteract = false;

    void Start()
    {
        interactHint = Instantiate(interactHint);
        interactHint.SetActive(false);

        input.Player.Interact.performed += ctx =>
        {
            if (!isInInteract)
            {
                if (interactObj != null && interfaceObj != null)
                {
                    isInInteract = true;
                    transform.LookAt(interactObj.transform.position);
                    interfaceObj.InteractEnter();
                    GetComponent<MoveController>().HandlerMovement(false);
                    interactHint.SetActive(false);
                }
            }
            else
            {
                isInInteract = false;
                GetComponent<MoveController>().HandlerMovement(true);
            }
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable component = other.GetComponent<IInteractable>();

        if (component != null)
        {
            interactObj = other.gameObject;
            interfaceObj = component;
            interactHint.transform.position = interactObj.transform.position + new Vector3(0f, 3f, 0f);
            interactHint.SetActive(true);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable component = other.GetComponent<IInteractable>();

        if (component != null)
        {
            interactObj = null;
            interfaceObj = null;
            interactHint.SetActive(false);
        }
    }
}
