using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAttackingState", menuName = "CharacterStates/Enemy/EnemyAttackingState")]

public class EnemyAttackingState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        for (int i = 0; i < deactivatedComponents.Length; i++)
        {
            statemachine?.EnableComp(deactivatedComponents[i], false);
        }

        statemachine.MBEvent?.Invoke(null, "Attacking");
        statemachine.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Attacking");
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
            for (int i = 0; i < activatedComponents.Length; i++)
            {
                statemachine?.EnableComp(activatedComponents[i], true);
            }
        }
    }
}
