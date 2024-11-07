using UnityEngine;

public abstract class State : ScriptableObject
{
    public Trait[] activatedComponents,deactivatedComponents;
    public Trait stateKey;
    public float maxTimeInState;
    public abstract void OnEnter(Statemachine statemachine);
    public abstract void OnUpdate(Statemachine statemachine);
    public abstract void OnExit(Statemachine statemachine);
}

