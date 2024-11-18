using UnityEngine;
using UnityEngine.InputSystem;

public class SecondSkillHandler : SkillHandler
{
    public CharacterSkill Skill2;
    public override void Awake()
    {
        base.Awake();
        canExecute = true;
    }
    private void OnEnable()
    {
        Skill2.OnSetup(character);

        if (Skill2 != null)
        {
            cost = Skill2.cost;
            input.action.performed += OnExecute;
            input.action.canceled += OnExecute;
        }
    }

    private void OnDisable()
    {
        Skill2.OnRemove(character);
        if (Skill2 != null)
        {
            input.action.performed -= OnExecute;
            input.action.canceled -= OnExecute;
        }
    }
    public void OnChangeSkill(CharacterBasicAttack newSkill)
    {
        Skill2.OnRemove(character);
        Skill2 = newSkill;
        Skill2.OnSetup(character);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
    }
    public void OnExecute(InputAction.CallbackContext context)
    {
        if (canExecute)
        {
            if (character.statDictionary[cost.stat].statValue >= cost.cost)
            {
                executionTime = Time.time;
                canExecute = false;

                if (context.performed)
                {
                    Skill2.OnHold(Skill2.statAndMultiplier);
                    MBEvent?.Invoke(Skill2.key[0], null);
                    statemachine.MBEvent?.Invoke(Skill2.key[0], Skill2.movementData[0]);
                    timeToExceed = Skill2.cooldown[0];

                    MBEvent?.Invoke(cost.stat, -cost.cost);

                }
                if (context.canceled)
                {
                    Skill2.OnRelease(Skill2.statAndMultiplier);
                    MBEvent?.Invoke(Skill2.key[0], null);
                    statemachine.MBEvent?.Invoke(Skill2.key[0], Skill2.movementData[0]);
                }
            }

        }


    }

    public override void Update()
    {
        base.Update();
    }
    public void OnChangeSkill(CharacterSkill characterSkill)
    {
        Skill2.OnRemove(character);
        Skill2 = characterSkill;
        Skill2.OnSetup(character);
    }
}
