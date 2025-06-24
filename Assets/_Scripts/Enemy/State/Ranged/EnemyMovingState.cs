using UnityEngine;
[CreateAssetMenu(fileName = "EnemyMovingState", menuName = "CharacterStates/Enemy/Ranged/EnemyMovingState")]

public class EnemyMovingState : EnemyState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);

        statemachine?.MBEvent?.Invoke(null, "Moving");
        statemachine?.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine?.MBEvent?.Invoke(null, "Moving");
        statemachine?.MBEvent?.Invoke(null, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
    }
}
