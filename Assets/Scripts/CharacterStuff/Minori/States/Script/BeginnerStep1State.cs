using UnityEngine;

[CreateAssetMenu(fileName = "BeginnerStep1", menuName = "CharacterStates/Minori/BasicAttack/BeginnerStep1")]
public class BeginnerStep1State : BasicAttackState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.timeInState = 0;
        statemachine.MBEvent?.Invoke(stateKey,"AttackCount");
        statemachine.MBEvent?.Invoke(stateKey,(float) 0);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
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
