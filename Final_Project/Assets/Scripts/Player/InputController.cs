using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public PlayerControls input;

    private void Awake()
    {
        input = new PlayerControls();
    }

    public PlayerControls getInput()
    {
        return input;
    }

    private void OnEnable()
    {
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }
}
