using UnityEngine;
[CreateAssetMenu(fileName = "EnemyDetectedState", menuName = "CharacterStates/Enemy/EnemyDetectedState")]

public class EnemyDetectedState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        for (int i = 0; i < deactivatedComponents.Length; i++)
        {
            statemachine.EnableComp(deactivatedComponents[i], false);
        }
        statemachine.MBEvent?.Invoke(null, "Detected");
        statemachine.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Detected");
        statemachine.MBEvent?.Invoke(null, false);
        //throw new System.NotImplementedException();
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
            //statemachine.ChangeState(statemachine.previousState);
        }
    }
}
