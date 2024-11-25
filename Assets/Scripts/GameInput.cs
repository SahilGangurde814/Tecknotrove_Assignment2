using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnFireAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Fire.performed += Fire_performed;
    }

    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnFireAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementInput()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }


}
