using UnityEngine;
using UnityEngine.InputSystem;

public class UIReferencer : EventHandler
{
    public PlayerInput input;
    public InputActionReference[] references;
    public GameObject[] turnOnWhenDisable;
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
        if (turnOnWhenDisable.Length > 0)
        {
            for (int i = 0; i < turnOnWhenDisable.Length; i++)
            {
                turnOnWhenDisable[i].SetActive(false);
            }
        }
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

        if(turnOnWhenDisable.Length>0)
        {
            for (int i = 0; i < turnOnWhenDisable.Length; i++)
            {
                turnOnWhenDisable[i].SetActive(true);
            }
        }
        //input.input.UI.Disable();
    }
}
