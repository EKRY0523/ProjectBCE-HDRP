using UnityEngine;


public class CharacterUltimateState : AttackingState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        if(statemachine.transform.parent!=null)
        {
            statemachine.transform.parent.tag = "Invulnerable";
        }
        statemachine.MBEvent?.Invoke(stateKey, "Ultimate");
        statemachine.MBEvent?.Invoke(stateKey, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        if (statemachine.transform.parent != null)
        {
            statemachine.transform.parent.tag = "Player";
        }
        statemachine.MBEvent?.Invoke(stateKey, "Ultimate");
        statemachine.MBEvent?.Invoke(stateKey, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
    }
}
