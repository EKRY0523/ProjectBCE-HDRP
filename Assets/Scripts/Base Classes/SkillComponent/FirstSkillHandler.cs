using UnityEngine;
using UnityEngine.InputSystem;

public class FirstSkillHandler : SkillHandler
{
    public CharacterSkill Skill1;
    public override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        Skill1.OnSetup(character);
        if (Skill1 != null)
        {
            input.action.performed += OnExecute;
        }
    }

    private void OnDisable()
    {
        Skill1.OnRemove(character);
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
        MBEvent?.Invoke(Skill1.key[0], null);
        statemachine.MBEvent?.Invoke(Skill1.key[0], Skill1.movementData[0]);

    }
    public void OnChangeSkill(CharacterSkill characterSkill)
    {
        Skill1.OnRemove(character);
        Skill1 = characterSkill;
        Skill1.OnSetup(character);
    }
    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
    }
}
