using UnityEngine;
[CreateAssetMenu(fileName = "BeginnerStep3", menuName = "CharacterStates/Minori/BasicAttack/BeginnerStep3")]
public class BeginnerStep3State : BasicAttackState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.timeInState = 0;
        statemachine.MBEvent?.Invoke(stateKey, "AttackCount");
        statemachine.MBEvent?.Invoke(stateKey, (float)2);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        //statemachine.MBEvent?.Invoke(stateKey, "Attacking");
        //statemachine.MBEvent?.Invoke(stateKey, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
    }
}
