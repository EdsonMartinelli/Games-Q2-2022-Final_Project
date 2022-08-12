using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour,IInteractable
{
    private bool isOpen = false;
    private Vector3 originalPos;
    private Vector3 offset;


    private void Awake()
    {
        originalPos = transform.position;
        offset = new Vector3(0f, 1.5f, 0f);
    }
    public void InteractionEnter()
    {
        isOpen = true;
    }

    public bool isInteractionCompleted()
    {
        isOpen = false;
        return isOpen;
    }


    public string GetInteractionType()
    {
        return InteractionType.Object.ToString();
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, originalPos + offset, Time.deltaTime * 10);
        } else
        {
            transform.position = Vector3.Lerp(transform.position, originalPos, Time.deltaTime * 10);
        }
    }
}
