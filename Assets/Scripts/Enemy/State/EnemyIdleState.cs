using UnityEngine;

[CreateAssetMenu(fileName = "EnemyIdleState", menuName = "CharacterStates/Enemy/EnemyIdleState")]
public class EnemyIdleState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        for (int i = 0; i < deactivatedComponents.Length; i++)
        {
            statemachine.EnableComp(deactivatedComponents[i], false);
        }
        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        //throw new System.NotImplementedException();
        

    }

    public override void OnUpdate(Statemachine statemachine)
    {
        //throw new System.NotImplementedException();

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
            //statemachine.ChangeState(statemachine.previousState);
        }
    }
}
