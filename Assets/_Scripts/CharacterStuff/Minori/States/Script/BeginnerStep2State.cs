using UnityEngine;
[CreateAssetMenu(fileName = "BeginnerStep2", menuName = "CharacterStates/Minori/BasicAttack/BeginnerStep2")]
public class BeginnerStep2State : BasicAttackState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.timeInState = 0;
        statemachine.MBEvent?.Invoke(stateKey, "AttackCount");
        statemachine.MBEvent?.Invoke(stateKey, (float)1);
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
        //statemachine.timeInState += Time.deltaTime;
        //Debug.Log(statemachine.timeInState);
        //if(statemachine.timeInState > 5f)
        //{
        //    statemachine.ChangeStateByType(typeof(MinoriIdleState));
        //}
    }
}
