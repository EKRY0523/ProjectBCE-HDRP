using UnityEngine;
using UnityEngine.InputSystem;

public class UIControl : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputActionReference InputEnable;
    public InputActionReference[] InputToDisable;


    private void OnEnable()
    {
        InputEnable.action.performed += ManageInput;
        InputEnable.action.started += ManageInput;
        InputEnable.action.canceled += ManageInput;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        InputEnable.action.performed -= ManageInput;
        InputEnable.action.started -= ManageInput;
        InputEnable.action.canceled -= ManageInput;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ManageInput(InputAction.CallbackContext ctx)
    {
        if(ctx.performed || ctx.started)
        {
            for (int i = 0; i < InputToDisable.Length; i++)
            {
                InputToDisable[i].action.Disable();
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (ctx.canceled)
        {
            for (int i = 0; i < InputToDisable.Length; i++)
            {
                InputToDisable[i].action.Enable();
            }
            playerInput.input.Player.Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void DisableInput()
    {
        for (int i = 0; i < InputToDisable.Length; i++)
        {
            InputToDisable[i].action.Disable();
        }

        playerInput.input.Player.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EnableInput()
    {
        for (int i = 0; i < InputToDisable.Length; i++)
        {
            InputToDisable[i].action.Enable();
        }
        playerInput.input.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
