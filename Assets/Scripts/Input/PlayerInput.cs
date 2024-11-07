using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(fileName = "Input", menuName = "CustomEvent/PlayerInput")]

public class PlayerInput : ScriptableObject, Controls.IPlayerActions
{
    public Controls input;
    public Action AttackInput,HoldInput,ReleaseAttackInput;
    public Action DodgeInput;
    public Action JumpInput;

    public Action<Vector2> MovementInput;
    public Action Skill1Input,Skill2Input,UltimateInput;
    public Action SwitchOne,SwitchTwo,SwitchThree;

    private void OnEnable()
    {
        if (input == null)
        {
            input = new Controls();
            input.Player.SetCallbacks(this);
        }

        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            AttackInput?.Invoke();
        }
        else if(context.performed)
        {
            HoldInput?.Invoke();
        }
        else if(context.canceled)
        {
            ReleaseAttackInput?.Invoke();
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            DodgeInput?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput?.Invoke();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementInput?.Invoke(context.ReadValue<Vector2>());
        
    }

    public void OnSkill1(InputAction.CallbackContext context)
    {
        Skill1Input?.Invoke();
    }

    public void OnSkill2(InputAction.CallbackContext context)
    {
        Skill2Input?.Invoke();
    }

    public void OnUltimate(InputAction.CallbackContext context)
    {
        UltimateInput?.Invoke();
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        
    }

    public void OnSwitchOne(InputAction.CallbackContext context)
    {
        
            SwitchOne?.Invoke();
        
    }

    public void OnSwitchTwo(InputAction.CallbackContext context)
    {
        
            SwitchTwo?.Invoke();
        
    }

    public void OnSwitchThree(InputAction.CallbackContext context)
    {
        
            SwitchThree?.Invoke();
        
    }

    public void OnWalkSwitch(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnSave(InputAction.CallbackContext context)
    {
    }
}
