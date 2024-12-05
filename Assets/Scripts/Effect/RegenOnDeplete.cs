using UnityEngine;
using System;
[CreateAssetMenu(fileName = "RegenOnDeplete", menuName = "Effect/RegenOnDeplete")]
public class RegenOnDeplete : Effect
{
    public override void PassiveOverTime(Entity entity, EffectHandler target)
    {
        base.PassiveOverTime(entity, target);
        target.MBEvent?.Invoke(targetedStat[0], entity.statDictionary[targetedStat[0]].MinMaxValue[1] * tick);
        
    }

    public override void CheckForCondition(Entity entity, EffectHandler target)
    {
        base.CheckForCondition(entity, target);
        //if(entity.statDictionary.ContainsKey(targetedStat[0]))
        //{
            if (entity.statDictionary[targetedStat[0]].statValue < entity.statDictionary[targetedStat[0]].MinMaxValue[1])
            {
                target.passiveDictionary[this].conditionMet = true;
            }
            else
            {
                target.passiveDictionary[this].conditionMet = false;
            }
        //}
        
    }
}
