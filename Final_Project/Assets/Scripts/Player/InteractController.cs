using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractController : MonoBehaviour
{
    private GameObject interactObj = null;
    private IInteractable interfaceObj = null;
    private bool isInInteract = false;

    private void Update()
    {
        if (InputControllerSystem.GetInstance().GetInteract())
        {
            if (interactObj != null && interfaceObj != null && !isInInteract)
            {
                isInInteract = true;
                interfaceObj.InteractEnter();
                ResourceSystem.GetResourceSystem().SetActiveHint(false);
                isInInteract = true;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable component = other.GetComponent<IInteractable>();

        if (component != null)
        {
            interactObj = other.gameObject;
            interfaceObj = component;
            Vector3 newPos = interactObj.transform.position + new Vector3(0f, 3f, 0f);
            ResourceSystem.GetResourceSystem().SetPositionHint(newPos);
            ResourceSystem.GetResourceSystem().SetActiveHint(true);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable component = other.GetComponent<IInteractable>();

        if (component != null)
        {
            component.InteractExit();
            interactObj = null;
            interfaceObj = null;
            isInInteract = false;
            ResourceSystem.GetResourceSystem().SetActiveHint(false);
        }
    }
}
