using UnityEngine;
using UnityEngine.InputSystem;

public class SecondSkillHandler : SkillHandler
{
    public CharacterSkill skill2;
    public override void Awake()
    {
        base.Awake();
        canExecute = true;
    }
    private void OnEnable()
    {
        skill2.OnSetup(character);
        if (skill2 != null)
        {
            input.action.performed += OnExecute;
            input.action.canceled += OnExecute;
        }
    }

    private void OnDisable()
    {
        skill2.OnRemove(character);
        if (skill2 != null)
        {
            input.action.performed -= OnExecute;
            input.action.canceled -= OnExecute;
        }
    }
    public void OnChangeSkill(CharacterBasicAttack newSkill)
    {
        skill2.OnRemove(character);
        skill2 = newSkill;
        skill2.OnSetup(character);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
    }
    public void OnExecute(InputAction.CallbackContext context)
    {
        if (canExecute)
        {
            if (context.performed)
            {
                skill2.OnHold(skill2.statAndMultiplier);
                MBEvent?.Invoke(skill2.key[0], null);
                statemachine.MBEvent?.Invoke(skill2.key[0], skill2.movementData[0]);

            }
            if (context.canceled)
            {
                skill2.OnRelease(skill2.statAndMultiplier);
                MBEvent?.Invoke(skill2.key[0], null);
                statemachine.MBEvent?.Invoke(skill2.key[0], skill2.movementData[0]);
            }

        }


    }

    public override void Update()
    {
        base.Update();
    }
    public void OnChangeSkill(CharacterSkill characterSkill)
    {
        skill2.OnRemove(character);
        skill2 = characterSkill;
        skill2.OnSetup(character);
    }
}
