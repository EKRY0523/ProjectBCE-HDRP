using UnityEngine;
using UnityEngine.InputSystem;

public class UIReferencer : EventHandler
{
    public PlayerInput input;
    public InputActionReference[] references;
    public override void Awake()
    {
        base.Awake();
       
    }

    private void OnEnable()
    {
        input.input.Player.Disable();
        for (int i = 0; i < references.Length; i++)
        {
            references[i].action.Disable();
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //input.input.UI.Enable();
    }

    private void OnDisable()
    {
        input.input.Player.Enable();
        for (int i = 0; i < references.Length; i++)
        {
            references[i].action.Enable();
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //input.input.UI.Disable();
    }
}
