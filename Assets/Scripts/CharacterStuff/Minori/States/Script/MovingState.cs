using UnityEngine;

[CreateAssetMenu(fileName = "MinoriMovingState", menuName = "CharacterStates/Minori/Moving")]
public class MovingState : CharacterState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "Moving");
        statemachine.MBEvent?.Invoke(stateKey, true);
        
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "Moving");
        statemachine.MBEvent?.Invoke(stateKey, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        
    }
}
