using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDeadState", menuName = "CharacterStates/Enemy/EnemyDeadState")]
public class EnemyDeadState : EnemyState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(null, "Dead");
    }

    public override void OnExit(Statemachine statemachine)
    {
        //base.OnExit(statemachine);
        //statemachine.MBEvent?.Invoke(null, "Dead");
    }

    public override void OnUpdate(Statemachine statemachine)
    {
    }
}
