using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CustomEvent", menuName = "CustomEvent/Custom")]
public class CustomEvent : ScriptableObject
{
    public Action<object> globalEvent;
    public virtual void OnInvoke()
    {
        //global event
    }
}
