using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField] public Trait[] activatedComponents,deactivatedComponents;
    [Header("OnEnterComponents")]
    [SerializeField]public Trait[] OnEnterActivateComponent;
    [SerializeField] public Trait[] OnEnterDeactivateComponent;
    [Header("OnExitComponents")]
    [SerializeField] public Trait[] OnExitActivateComponent;
    [SerializeField] public Trait[] OnExitDeactivateComponent;
    [SerializeField] public Trait SwitchUponExit;
    [Header("Value")]
    [SerializeField] public Trait stateKey;
    [SerializeField] public float maxTimeInState;
    public abstract void OnEnter(Statemachine statemachine);
    public abstract void OnUpdate(Statemachine statemachine);
    public abstract void OnExit(Statemachine statemachine);
}

