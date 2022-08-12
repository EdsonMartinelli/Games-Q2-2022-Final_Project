using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour,IInteractable
{
    private bool isOpen = false;
    private Quaternion originalRotate;
    private Transform pivot;
    [SerializeField] private float smoothRotate;

    private void Awake()
    {
        pivot = transform.parent.transform;
        originalRotate = pivot.transform.rotation;
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
            Quaternion rotate = Quaternion.Euler(0f, -90f, 0f);
            pivot.rotation = Quaternion.Lerp(pivot.rotation, rotate, Time.deltaTime * smoothRotate);
        } else
        {
            pivot.rotation = Quaternion.Lerp(pivot.rotation, originalRotate, Time.deltaTime * smoothRotate);
        }
    }
}
