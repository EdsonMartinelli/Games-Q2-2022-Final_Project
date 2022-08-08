using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotate;

    private void Update()
    {
        GetMovement();
        PlayerMove();
        PlayerRotate();
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

}
