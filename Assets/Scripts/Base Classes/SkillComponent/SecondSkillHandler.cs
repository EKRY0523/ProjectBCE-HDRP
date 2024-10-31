using UnityEngine;
using UnityEngine.InputSystem;
public class SecondSkillHandler : SkillHandler
{
    public CharacterSkill Skill2;
    public override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        Skill2.OnSetup(character);
        if (Skill2 != null)
        {
            input.action.performed += OnExecute;
        }
    }

    private void OnDisable()
    {
        Skill2.OnRemove(character);
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
        MBEvent?.Invoke(Skill2.key[0], null);
        statemachine.MBEvent?.Invoke(Skill2.key[0], Skill2.movementData[0]);

    }
    public void OnChangeSkill(CharacterSkill characterSkill)
    {
        Skill2.OnRemove(character);
        Skill2 = characterSkill;
        Skill2.OnSetup(character);
    }
    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
    }
}
