using UnityEngine;
using UnityEngine.InputSystem;
public class DodgeSkillHandler : SkillHandler
{
    public CharacterSkill dodge;
    public override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        dodge.OnSetup(character);
        if (dodge != null)
        {
            input.action.performed += OnExecute;
        }
    }

    private void OnDisable()
    {
        dodge.OnRemove(character);
    }
    public void OnChangeSkill(CharacterBasicAttack newSkill)
    {
        dodge.OnRemove(character);
        dodge = newSkill;
        dodge.OnSetup(character);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
    }
    public void OnExecute(InputAction.CallbackContext context)
    {
        MBEvent?.Invoke(dodge.key[0], null);
        statemachine.MBEvent?.Invoke(dodge.key[0], dodge.movementData[0]);

    }
    public void OnChangeSkill(CharacterSkill characterSkill)
    {
        dodge.OnRemove(character);
        dodge = characterSkill;
        dodge.OnSetup(character);
    }
    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
    }
}
