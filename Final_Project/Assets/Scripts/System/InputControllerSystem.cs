using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class InputControllerSystem : MonoBehaviour
{
    private static InputControllerSystem instance;
    private PlayerControls input;
    private InputAction move;
    private InputAction interact;

    private InputControllerSystem() { }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            input = new PlayerControls();
            move = input.Player.Move;
            interact = input.Player.Interact;
        }
    }

    public static InputControllerSystem GetInstance()
    {
        return instance;
    }

    public Vector2 GetMove()
    {
        return move.ReadValue<Vector2>();
    }

    public bool GetInteract()
    {
        return interact.WasReleasedThisFrame();
    }

    private void OnEnable() => input.Player.Enable();

    private void OnDisable() => input.Player.Disable();
}
