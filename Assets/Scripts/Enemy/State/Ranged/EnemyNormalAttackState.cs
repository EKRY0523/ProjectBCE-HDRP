using UnityEngine;
[CreateAssetMenu(fileName = "EnemyNormalAttackState", menuName = "CharacterStates/Enemy/Ranged/EnemyNormalAttackState")]
public class EnemyNormalAttackState : EnemyAttackingState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine?.MBEvent?.Invoke(null, "AttackType");
        statemachine?.MBEvent?.Invoke(null, (int)0);
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
