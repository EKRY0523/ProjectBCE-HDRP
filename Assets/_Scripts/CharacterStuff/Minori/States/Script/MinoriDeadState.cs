using UnityEngine;

[CreateAssetMenu(fileName = "MinoriDeadState", menuName = "CharacterStates/Minori/MinoriDeadState")]
public class MinoriDeadState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        statemachine.MBEvent.Invoke(null,"Dead");
        statemachine.MBEvent.Invoke(null,true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent.Invoke(null, "Dead");
        statemachine.MBEvent.Invoke(null, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {

    }
}
