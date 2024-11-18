using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAttackingState", menuName = "CharacterStates/Enemy/EnemyAttackingState")]

public class EnemyAttackingState : EnemyState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);

        statemachine.MBEvent?.Invoke(null, "Attacking");
        statemachine.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine.MBEvent?.Invoke(null, "Attacking");
        statemachine.MBEvent?.Invoke(null, false);
       
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
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
