using UnityEngine;
using UnityEngine.InputSystem;
public class UiPauser : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputActionReference[] InputToDisable;

    private void OnEnable()
    {
        for (int i = 0; i < InputToDisable.Length; i++)
        {
            InputToDisable[i].action.Disable();
        }
        playerInput.input.Player.Disable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
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
