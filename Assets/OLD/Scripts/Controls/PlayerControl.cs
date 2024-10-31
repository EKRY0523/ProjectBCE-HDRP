using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControl : MonoBehaviour
{
    public Controls input;
    public Controls.PlayerActions playerActions;
    public Vector2 movementInput;
    public Vector2 jumpInput;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        input = new Controls();
        playerActions = input.Player;
    }

    private void OnEnable()
    {
        playerActions.Enable();
        playerActions.Skill1.Enable();

        playerActions.Skill2.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
    private void Update()
    {
        movementInput = playerActions.Move.ReadValue<Vector2>();
        jumpInput = playerActions.Jump.ReadValue<Vector2>();


    }


}

