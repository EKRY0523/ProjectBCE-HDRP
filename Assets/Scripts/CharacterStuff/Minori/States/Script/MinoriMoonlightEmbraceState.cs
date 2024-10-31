using UnityEngine;

[CreateAssetMenu(fileName = "MoonlightEmbrace", menuName = "CharacterStates/Minori/Ultimate/MoonlightEmbrace")]

public class MinoriMoonlightEmbraceState : MinoriUltimateState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "UltimateType");
        statemachine.MBEvent?.Invoke(stateKey, (int)0);
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
