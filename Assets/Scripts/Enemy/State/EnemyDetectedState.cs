using UnityEngine;
[CreateAssetMenu(fileName = "EnemyDetectedState", menuName = "CharacterStates/Enemy/EnemyDetectedState")]

public class EnemyDetectedState : EnemyState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(null, "Detected");
        statemachine.MBEvent?.Invoke(null, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
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
            statemachine.OnInvoke(SwitchUponExit,null);
        }
    }
}
