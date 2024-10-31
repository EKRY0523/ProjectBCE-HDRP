using UnityEngine;
using System;
using System.Collections.Generic;

public class CustomEvent : ScriptableObject
{
    public Action<object> globalEvent;
    public virtual void OnInvoke()
    {
        //global event
    }
}
