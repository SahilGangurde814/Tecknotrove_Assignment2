using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameInput gameInput;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 inputVector = gameInput.GetMovementInput();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y).normalized;

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 relativeMoveDir = (cameraForward * moveDir.z + cameraRight * moveDir.x).normalized;

        transform.position += relativeMoveDir * speed * Time.deltaTime;

    }
}
