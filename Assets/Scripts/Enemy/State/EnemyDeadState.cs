using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDeadState", menuName = "CharacterStates/Enemy/EnemyDeadState")]
public class EnemyDeadState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        for (int i = 0; i < deactivatedComponents.Length; i++)
        {
            statemachine.EnableComp(deactivatedComponents[i], false);
        }
        statemachine.MBEvent?.Invoke(null, "Dead");
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Dead");
        //throw new System.NotImplementedException();
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        //throw new System.NotImplementedException();
    }
}
