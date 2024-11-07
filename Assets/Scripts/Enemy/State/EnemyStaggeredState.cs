using UnityEngine;
[CreateAssetMenu(fileName = "EnemyStaggeredState", menuName = "CharacterStates/Enemy/staggered")]

public class EnemyStaggeredState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Staggered");
        statemachine.MBEvent?.Invoke(null, true);
    }
    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Staggered");
        statemachine.MBEvent?.Invoke(null, false);
    }
    public override void OnUpdate(Statemachine statemachine)
    {
    }
}
