using UnityEngine;
[CreateAssetMenu(fileName = "EnemyChaseState", menuName = "CharacterStates/Enemy/EnemyChaseState")]

public class EnemyChaseState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Chase");
        statemachine.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Chase");
        statemachine.MBEvent?.Invoke(null, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        //throw new System.NotImplementedException();
    }
}
