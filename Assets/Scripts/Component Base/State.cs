using UnityEngine;

public abstract class State : ScriptableObject
{
    public Trait[] activatedComponents,deactivatedComponents;
    [Header("OnEnterComponents")]
    public Trait[] OnEnterActivateComponent;
    public Trait[] OnEnterDeactivateComponent;
    [Header("OnExitComponents")]
    public Trait[] OnExitActivateComponent;
    public Trait[] OnExitDeactivateComponent;
    public Trait SwitchUponExit;
    [Header("Value")]
    public Trait stateKey;
    public float maxTimeInState;
    public abstract void OnEnter(Statemachine statemachine);
    public abstract void OnUpdate(Statemachine statemachine);
    public abstract void OnExit(Statemachine statemachine);
}

