using UnityEngine;
using System;
public abstract class ReusableComponent : ScriptableObject
{
    public virtual void ExecuteAction(int integer) { }
    public virtual void ExecuteAction(Vector2 vector2) { }
    public virtual void ExecuteAction(Vector3 vector3) { }
    public virtual void ExecuteAction(Transform transform) { }
}
