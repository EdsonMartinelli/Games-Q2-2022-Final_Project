using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStartController : MonoBehaviour, IObject
{
    private bool isOpen = false;
    private bool isStarted = false;
    private bool enterInDoor = false;
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
        enterInDoor = true;
    }

    public void InteractionExit()
    {
        if (enterInDoor)
        {
            isStarted = true;
            GameManager.GetGameManager().StartStopwatch();
        }
    }

    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.Object;
    }

    private void Update()
    {
        if (isOpen && !isStarted)
        {
            pivot.rotation = Quaternion.Lerp(pivot.rotation, rotate, Time.deltaTime * smoothRotate);
        } else
        {
            pivot.rotation = Quaternion.Lerp(pivot.rotation, pivotRotate, Time.deltaTime * smoothRotate);
        }
    }
}
