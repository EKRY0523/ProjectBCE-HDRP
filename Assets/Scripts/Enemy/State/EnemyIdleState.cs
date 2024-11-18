using UnityEngine;

[CreateAssetMenu(fileName = "EnemyIdleState", menuName = "CharacterStates/Enemy/EnemyIdleState")]
public class EnemyIdleState : EnemyState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {

        if (statemachine.timeInState < maxTimeInState)
        {
            statemachine.timeInState += Time.deltaTime;
        }
        else
        {
            statemachine.OnInvoke(SwitchUponExit,null);
        }
    }
}
