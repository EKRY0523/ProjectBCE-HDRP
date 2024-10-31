using UnityEngine;

[CreateAssetMenu(fileName = "MinoriMovingState", menuName = "CharacterStates/Minori/Moving")]
public class MovingState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(stateKey, "Moving");
        statemachine.MBEvent?.Invoke(stateKey, true);
        
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(stateKey, "Moving");
        statemachine.MBEvent?.Invoke(stateKey, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        
    }
}
