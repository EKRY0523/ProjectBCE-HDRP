using UnityEngine;
[CreateAssetMenu(fileName = "RegenOnDeplete", menuName = "StatAction/RegenOnDeplete")]
public class RegenOnDeplete : StatAction
{
    public float regenRate;
    public override void HandleAction(Entity entity, Stat value)
    {
        if(value.MinMaxValue[1] <= value.statValue)
        {
            entity.statDictionary[value.statIdentifier].statValue += (value.MinMaxValue[1] * (value.statScaling * entity.level.lv) * regenRate);
            entity.StatHandler.MBEvent.Invoke(value.statIdentifier, entity.statDictionary[value.statIdentifier].statValue);
        }
        
    }

}
