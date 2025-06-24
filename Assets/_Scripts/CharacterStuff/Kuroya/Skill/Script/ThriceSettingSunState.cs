using UnityEngine;
[CreateAssetMenu(fileName = "Thrice Setting Sun", menuName = "CharacterStates/Kuroya/Skill/Thrice Setting Sun")]

public class ThriceSettingSunState : SkillState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "SkillType");
        statemachine.MBEvent?.Invoke(stateKey, (int)2);
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
