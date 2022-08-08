using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;
    private Collider interactObj = null;
    private bool isInInteract = false;

    [SerializeField] private float speed;
    [SerializeField] private float speedRotate;

    private void Update()
    {
        VerifyInteractEnter();
        VerifyInteractExit();
        if (!isInInteract)
        {
            GetMovement();
            PlayerMove();
            PlayerRotate();
        }
    }

    private void GetMovement()
    {
        movement = InputControllerSystem.GetInstance().GetMove();
    }

    private void PlayerMove()
    {
        Vector3 moveV3 = new Vector3(movement.x, 0f, movement.y);
        Quaternion rotate = Quaternion.Euler(0f, 45f, 0f);
        Vector3 direction = rotate * moveV3;
        transform.position = transform.position + direction * Time.deltaTime * speed;
    }

    private void PlayerRotate()
    {
        if (movement == Vector2.zero) return;

        float angle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + 45;
        Quaternion rotate = Quaternion.Euler(0f, angle, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * speedRotate);
    }

    private void VerifyInteractEnter()
    {
        if (InputControllerSystem.GetInstance().GetInteract())
        {
            if (!isInInteract)
            {
                if (interactObj != null)
                {
                    isInInteract = true;
                    interactObj.GetComponent<IInteractable>().InteractEnter();
                    ResourceSystem.GetResourceSystem().SetActiveHint(false);
                    isInInteract = true;
                }
            } 
        }
    }

    private void VerifyInteractExit()
    {
        if (isInInteract && interactObj != null)
        {
            if (interactObj.GetComponent<IInteractable>().InteractExit())
            {
                isInInteract = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable component = other.GetComponent<IInteractable>();

        if (component != null)
        {
            interactObj = other;
            Vector3 newPos = other.gameObject.transform.position + new Vector3(0f, 3f, 0f);
            ResourceSystem.GetResourceSystem().SetPositionHint(newPos);
            ResourceSystem.GetResourceSystem().SetActiveHint(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable component = other.GetComponent<IInteractable>();

        if (component != null)
        {
            interactObj = null;
            isInInteract = false;
            ResourceSystem.GetResourceSystem().SetActiveHint(false);
        }
    }
}
