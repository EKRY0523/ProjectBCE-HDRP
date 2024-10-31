using UnityEngine;

[CreateAssetMenu(fileName = "MinoriBasicAttackState", menuName = "CharacterStates/Minori/BasicAttack")]
public class BasicAttackState : AttackingState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "Basic");
        statemachine.MBEvent?.Invoke(stateKey, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "Basic");
        statemachine.MBEvent?.Invoke(stateKey, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
       
    }
}
