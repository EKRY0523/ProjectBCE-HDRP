using UnityEngine;

public class EnemyState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        for (int i = 0; i < OnEnterActivateComponent.Length; i++)
        {
            statemachine.EnableComp(OnEnterActivateComponent[i], true);
        }
        for (int i = 0; i < OnEnterDeactivateComponent.Length; i++)
        {
            statemachine.EnableComp(OnEnterDeactivateComponent[i], false);
        }
    }

    public override void OnExit(Statemachine statemachine)
    {
        for (int i = 0; i < OnExitActivateComponent.Length; i++)
        {
            statemachine.EnableComp(OnExitActivateComponent[i], true);
        }
        for (int i = 0; i < OnExitDeactivateComponent.Length; i++)
        {
            statemachine.EnableComp(OnExitDeactivateComponent[i], false);
        }
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        //throw new System.NotImplementedException();
    }
}
