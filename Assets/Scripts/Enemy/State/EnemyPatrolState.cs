using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPatrolState", menuName = "CharacterStates/Enemy/Patrol")]
public class EnemyPatrolState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, false);
        //throw new System.NotImplementedException();
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        //throw new System.NotImplementedException();
    }
}
