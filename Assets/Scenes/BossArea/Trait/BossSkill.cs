using UnityEngine;
[CreateAssetMenu(fileName = "BossSkill", menuName = "CharacterStates/Enemy/Skill/state")]

public class BossSkill : SkillState
{
    public int count;
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "SkillType");
        statemachine.MBEvent?.Invoke(stateKey, (int)count);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
    }
}
