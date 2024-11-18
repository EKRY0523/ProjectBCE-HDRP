using UnityEngine;
[CreateAssetMenu(fileName = "EnemyStaggeredState", menuName = "CharacterStates/Enemy/staggered")]

public class EnemyStaggeredState : EnemyState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(null, "Staggered");
        statemachine.MBEvent?.Invoke(null, true);
        statemachine.MBEvent?.Invoke(null,50);
    }
    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine.MBEvent?.Invoke(null, "Staggered");
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
            statemachine.OnInvoke(SwitchUponExit, null);
        }
    }
}
