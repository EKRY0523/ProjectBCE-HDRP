using UnityEngine;
[CreateAssetMenu(fileName = "CharacterDodge2State", menuName = "CharacterStates/CharacterDodge2State")]

public class CharacterDodge2State : CharacterDodgeState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "DodgeType");
        statemachine.MBEvent?.Invoke(stateKey, (int)1);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine.transform.parent.tag = "Player";
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);

    }
}
