using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;
    private Collider interactObj = null;
    private bool isInDialogue = false;
    private bool isInInteraction = false;
    private Inventory inventory;

    [SerializeField] private float speed;
    [SerializeField] private float speedRotate;


    private void Awake()
    {
        inventory = new Inventory(3); 
    }

    private void Update()
    {
        VerifyInteractionEnter();
        if (!isInDialogue)
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
        transform.position = transform.position +  (Time.deltaTime * speed * direction);
    }

    private void PlayerRotate()
    {
        if (movement == Vector2.zero) return;

        float angle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + 45;
        Quaternion rotate = Quaternion.Euler(0f, angle, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * speedRotate);
    }

    private void VerifyInteractionEnter()
    {
        if (InputControllerSystem.GetInstance().GetInteract())
        {
            if (!isInInteraction && interactObj != null)
            {
                IInteractable.InteractionType typeOfInteraction = interactObj.GetComponent<IInteractable>().GetInteractionType();
                isInInteraction = true;
                ResourceSystem.GetResourceSystem().SetActiveHint(false);

                switch (typeOfInteraction)
                {
                    case IInteractable.InteractionType.NPC:
                        isInDialogue = true;
                        DialogueUISystem.GetDialogueUISystem().DialogueCompleted += () => VerifyIfDialogueIsCompleted();
                        interactObj.GetComponent<INPC>().DialogueEnter();
                        break;

                    case IInteractable.InteractionType.Object:
                        interactObj.GetComponent<IObject>().InteractionEnter();
                        break;

                    case IInteractable.InteractionType.Machine:
                        Item newItem = interactObj.GetComponent<IMachine>().GetItem();
                        string texto = string.Empty;
                        if (inventory.AddItem(newItem))
                        {
                            foreach(Item itenzinho in inventory.GetQueue().ToArray())
                            {
                                texto = texto + " " + itenzinho.GetItemType();
                            }
                            print(texto);
                        } else
                        {
                            print("A fila est� cheia.");
                        }
                        isInInteraction = false;
                        ResourceSystem.GetResourceSystem().SetActiveHint(true);
                        break;

                    case IInteractable.InteractionType.Trash:
                        bool wasItemRemoved = interactObj.GetComponent<ITrash>().RemoveItem(inventory);
                        string texto2 = string.Empty;
                        if (wasItemRemoved)
                        {
                            foreach (Item itenzinho in inventory.GetQueue().ToArray())
                            {
                                texto2 = texto2 + " " + itenzinho.GetItemType();
                            }
                            print(texto2);
                        } else
                        {
                            print("N�o existia itens para serem removidos");
                        }
                        isInInteraction = false;
                        ResourceSystem.GetResourceSystem().SetActiveHint(true);
                        break;

                    default: break;
                }
            } 
        }
    }

    private void VerifyIfDialogueIsCompleted()
    {
        DialogueUISystem.GetDialogueUISystem().DialogueCompleted -= () => VerifyIfDialogueIsCompleted();
        isInDialogue = false;
        interactObj = null;
        isInInteraction = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable component = other.GetComponent<IInteractable>();

        if (component != null)
        {
            interactObj = other;
            Transform objectTransform = other.gameObject.transform;
            Vector3 positionNeutralite = new Vector3(objectTransform.position.x, 0f, objectTransform.position.z);
            Vector3 newPos = positionNeutralite + new Vector3(0f, other.bounds.size.y + 2f, 0f);
            ResourceSystem.GetResourceSystem().SetPositionHint(newPos);
            ResourceSystem.GetResourceSystem().SetRotationHint(other.gameObject.transform.rotation);
            ResourceSystem.GetResourceSystem().SetActiveHint(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable component = other.GetComponent<IInteractable>();

        if (component != null)
        {
            if (component.GetInteractionType() == IInteractable.InteractionType.Object)
            {
                other.GetComponent<IObject>().InteractionExit();
                isInInteraction = false;
            }
            interactObj = null;
            ResourceSystem.GetResourceSystem().SetActiveHint(false);
        }
    }
}
