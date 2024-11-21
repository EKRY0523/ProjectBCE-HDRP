using UnityEngine;
[CreateAssetMenu(fileName = "EnemyCloseRangeAttackState", menuName = "CharacterStates/Enemy/Ranged/EnemyCloseRangeAttackState")]


public class EnemyCloseRangeAttackState : EnemyAttackingState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine?.MBEvent?.Invoke(null, "AttackType");
        statemachine?.MBEvent?.Invoke(null,(int)2);

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
