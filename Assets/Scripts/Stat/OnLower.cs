using UnityEngine;

public class OnLower : StatAction
{
    public float threshold;
    public override void HandleAction(Entity entity, Stat value)
    {
        if (value.statValue <= threshold)
        {
            entity.MBEvent?.Invoke(actionID, null);
            //can also make dumbasses dissapear and summon vfx
        }
    }
}
