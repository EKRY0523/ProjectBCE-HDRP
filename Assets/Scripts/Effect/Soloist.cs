using UnityEngine;
using System;
public class Soloist : Effect
{
    public override void PassiveOneShot(Entity entity, EffectHandler target)
    {
        base.PassiveOneShot(entity, target);
        if(entity.GetComponent<PartyHandler>().characterList.Count ==1)
        {
            target.MBEvent?.Invoke(targetedStat[0], entity.statDictionary[targetedStat[0]].statValue * 3); //atk
            target.MBEvent?.Invoke(targetedStat[1], entity.statDictionary[targetedStat[1]].statValue * 1.5); //def
        }
        else
        {
            target.MBEvent?.Invoke(targetedStat[0], entity.statDictionary[targetedStat[0]].statValue * 0); //atk
            target.MBEvent?.Invoke(targetedStat[0], entity.statDictionary[targetedStat[0]].MinMaxValue[1] * Mathf.Pow(entity.statDictionary[targetedStat[0]].statScaling,entity.level.lv-1)); //atk
            target.MBEvent?.Invoke(targetedStat[1], entity.statDictionary[targetedStat[1]].statValue * 0); //def
            target.MBEvent?.Invoke(targetedStat[1], entity.statDictionary[targetedStat[1]].statValue * Mathf.Pow(entity.statDictionary[targetedStat[0]].statScaling, entity.level.lv - 1)); //def
        }
    }

}
