using UnityEngine;
using System;
using System.Collections.Generic;

public class Statemachine : EventHandler
{
    public Dictionary<Trait, State> stateDictionary = new Dictionary<Trait, State>();
    public float timeInState;
    public StateBinder[] keyAndStates;
    public State currentState;
    public State previousState;

    public State startingState;

    public List<State> previousStates;

    public override void Awake()
    {
        base.Awake();

        for (int i = 0; i < keyAndStates.Length; i++)
        {
            stateDictionary.Add(keyAndStates[i].key,keyAndStates[i].state);
        }
        currentState = keyAndStates[0].state;
        startingState = keyAndStates[0].state;
    }

    private void Update()
    {
        currentState?.OnUpdate(this);
    }
    public void ChangeState(State newState)
    {
        timeInState = 0;
        currentState.OnExit(this);
        previousState = currentState;
        currentState = newState;
        currentState.OnEnter(this);
    }
    public void ResumePreviousState()
    {
        currentState.OnExit(this);
        currentState = previousState;
        currentState.OnEnter(this);
    }


    public override void OnInvoke(Trait ID,object data)
    {
        base.OnInvoke(ID,data);
        if(ID!=null)
        {
            if (stateDictionary.ContainsKey(ID))
            {
                ChangeState(stateDictionary[ID]);
            }
        }

    }

    public void OnPause()
    {

    }
}
