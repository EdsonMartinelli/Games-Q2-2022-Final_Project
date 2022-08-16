using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IObject
{
    private bool isOpen = false;
    private Quaternion pivotRotate;
    private Transform pivot;
    private Quaternion rotate;
    [SerializeField] private float smoothRotate;

    private void Awake()
    {

        pivot = transform.parent.transform;
        pivotRotate = pivot.transform.rotation;
        rotate = Quaternion.Euler(0f, -90f, 0f) * pivot.rotation;
    }
    public void InteractionEnter()
    {
        isOpen = true;
    }

    public void InteractionExit()
    {
        isOpen = false;
    }

    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.Object;
    }

    private void Update()
    {
        if (isOpen)
        {
            pivot.rotation = Quaternion.Lerp(pivot.rotation, rotate, Time.deltaTime * smoothRotate);
        } else
        {
            pivot.rotation = Quaternion.Lerp(pivot.rotation, pivotRotate, Time.deltaTime * smoothRotate);
        }
    }
}
