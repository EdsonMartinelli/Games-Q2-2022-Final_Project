using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : InputController
{
    private Vector2 movement = Vector2.zero;
    public float speed;
    public float speedRotate;
    private bool canMove = true;

    void Start()
    {
        input.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>().normalized;

        input.Player.Move.canceled += ctx => movement = Vector2.zero;
    }

    void Update()
    {
        if(canMove)
        {
            PlayerMove();
            PlayerRotate();
        }
    }

    public void HandlerMovement(bool playerMove)
    {
        canMove = playerMove;
    }

    void PlayerMove()
    {
        Vector3 moveV3 = new Vector3(movement.x, 0f, movement.y);
        Quaternion rotate = Quaternion.Euler(0f, 45f, 0f);
        Vector3 direction = rotate * moveV3;
        transform.position = transform.position + direction * Time.deltaTime * speed;
    }

    void PlayerRotate()
    {
        if (movement == Vector2.zero) return;

        float angle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + 45;
        Quaternion rotate = Quaternion.Euler(0f, angle, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * speedRotate);
    }

}
