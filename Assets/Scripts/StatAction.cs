using UnityEngine;

public class StatAction : ScriptableObject
{
    public Trait actionID; //execute certain states at certain threshold, usable for boss
    public virtual void HandleAction(Entity entity, Stat value)
    {

    }
}
