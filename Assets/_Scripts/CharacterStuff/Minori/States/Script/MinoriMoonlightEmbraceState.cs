using UnityEngine;

[CreateAssetMenu(fileName = "MoonlightEmbrace", menuName = "CharacterStates/Minori/Ultimate/MoonlightEmbrace")]

public class MinoriMoonlightEmbraceState : CharacterUltimateState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "UltimateType");
        statemachine.MBEvent?.Invoke(stateKey, (int)1);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);

    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
    }
}
