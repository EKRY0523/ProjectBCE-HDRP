using UnityEngine;
[CreateAssetMenu(fileName = "BerserkerWill", menuName = "CharacterStates/Kuroya/Skill/BerserkerWill")]
public class BerserkerWillState : SkillState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "SkillType");
        statemachine.MBEvent?.Invoke(stateKey, (int)0);
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