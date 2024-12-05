using UnityEngine;

public class CharacterState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        if(OnEnterActivateComponent != null )
        {
            if (OnEnterActivateComponent.Length > 0)
            {
                for (int i = 0; i < OnEnterActivateComponent.Length; i++)
                {
                    statemachine?.EnableComp(OnEnterActivateComponent[i], true);
                }

            }
            if (OnEnterDeactivateComponent.Length > 0)
            {
                for (int i = 0; i < OnEnterDeactivateComponent.Length; i++)
                {
                    statemachine?.EnableComp(OnEnterDeactivateComponent[i], false);
                }
            }
        }
        

    }

    public override void OnExit(Statemachine statemachine)
    {
        if(OnExitActivateComponent != null)
        {

            if (OnExitActivateComponent.Length > 0)
            {
                for (int i = 0; i < OnExitActivateComponent.Length; i++)
                {
                    statemachine?.EnableComp(OnExitActivateComponent[i], true);
                }
            }

            if (OnExitDeactivateComponent != null || OnExitDeactivateComponent.Length > 0)
            {
                for (int i = 0; i < OnExitDeactivateComponent.Length; i++)
                {
                    statemachine?.EnableComp(OnExitDeactivateComponent[i], false);
                }
            }
        }
        
    }

    public override void OnUpdate(Statemachine statemachine)
    {
    }
}
