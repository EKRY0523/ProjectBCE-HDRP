using UnityEngine;
using UnityEngine.InputSystem;
public class UltimateSkillHandler : SkillHandler
{
    public CharacterSkill ultimate;
    public override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        ultimate.OnSetup(character);
        if (ultimate != null)
        {
            input.action.performed += OnExecute;
        }
    }

    private void OnDisable()
    {
        ultimate.OnRemove(character);
    }
    public void OnChangeSkill(CharacterBasicAttack newSkill)
    {
        ultimate.OnRemove(character);
        ultimate = newSkill;
        ultimate.OnSetup(character);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
    }
    public void OnExecute(InputAction.CallbackContext context)
    {
        MBEvent?.Invoke(ultimate.key[0], null);
        statemachine.MBEvent?.Invoke(ultimate.key[0], ultimate.movementData[0]);

    }
    public void OnChangeSkill(CharacterSkill characterSkill)
    {
        ultimate.OnRemove(character);
        ultimate = characterSkill;
        ultimate.OnSetup(character);
    }
    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
    }
}
