using UnityEngine;
using UnityEngine.InputSystem;

public class FirstSkillHandler : SkillHandler
{
    public CharacterSkill Skill1;
    public override void Awake()
    {
        base.Awake();
        
        canExecute = true;
    }
    private void OnEnable()
    {
        Skill1.OnSetup(character);

        cost = Skill1.cost;
        if (Skill1 != null)
        {
            input.action.performed += OnExecute;
            input.action.canceled += OnExecute;
        }
    }

    private void OnDisable()
    {
        Skill1.OnRemove(character);
        if (Skill1 != null)
        {
            input.action.performed -= OnExecute;
            input.action.canceled -= OnExecute;
        }
    }
    public void OnChangeSkill(CharacterBasicAttack newSkill)
    {
        Skill1.OnRemove(character);
        Skill1 = newSkill;
        Skill1.OnSetup(character);
    }

    public override void OnInvoke(Trait ID,object data)
    {
        base.OnInvoke(ID,data);
    }
    public void OnExecute(InputAction.CallbackContext context)
    {
        if(canExecute)
        {
           
            if (character.statDictionary[cost.stat].statValue >= cost.cost)
            {
                executionTime = Time.time;
                canExecute = false;

                if (context.performed)
                {
                    Skill1.OnHold(Skill1.statAndMultiplier);
                    MBEvent?.Invoke(Skill1.key[0], null);
                    statemachine.MBEvent?.Invoke(Skill1.key[0], Skill1.movementData[0]);
                    timeToExceed = Skill1.cooldown[0];
                    MBEvent?.Invoke(cost.stat,-cost.cost);

                }
                if (context.canceled)
                {
                    Skill1.OnRelease(Skill1.statAndMultiplier);
                    MBEvent?.Invoke(Skill1.key[0], null);
                    statemachine.MBEvent?.Invoke(Skill1.key[0], Skill1.movementData[0]);
                }
            }
            
        }


    }

    public override void Update()
    {
        base.Update();
    }

    public void SpawnSkill1Object(int instance)
    {

        //Debug.Log((Skill1.skillInstance[0].skillObjects[instance].multiplier));
        Instantiate(Skill1.skillInstance[0].skillObjects[instance], transform.parent);
    }
    public void OnChangeSkill(CharacterSkill characterSkill)
    {
        Skill1.OnRemove(character);
        Skill1 = characterSkill;
        Skill1.OnSetup(character);
    }
}
