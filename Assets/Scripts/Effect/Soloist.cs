using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Soloist", menuName = "Effect/Passive/Soloist")]

public class Soloist : Effect
{
    public override void PassiveOverTime(Entity entity, EffectHandler target)
    {
        base.PassiveOverTime(entity, target);
        if (GameManager.instance.charactersInParty.Count == 1)
        {
            target.MBEvent?.Invoke(targetedStat[2], entity.statDictionary[targetedStat[2]].MinMaxValue[1] * tick);
        }

    }
    public override void PassiveOneShot(Entity entity, EffectHandler target)
    {
        base.PassiveOneShot(entity, target);
        
        if (GameManager.instance.charactersInParty.Count == 1)
        {
            target.MBEvent?.Invoke(targetedStat[0], -entity.statDictionary[targetedStat[0]].statValue);
            target.MBEvent?.Invoke(targetedStat[0], (entity.statDictionary[targetedStat[0]].MinMaxValue[1] * value[0])); //atk
            target.MBEvent?.Invoke(targetedStat[1], -entity.statDictionary[targetedStat[1]].statValue);
            target.MBEvent?.Invoke(targetedStat[1], entity.statDictionary[targetedStat[1]].MinMaxValue[1] * value[1]); //def
        }
        else
        {
            target.MBEvent?.Invoke(targetedStat[0], -entity.statDictionary[targetedStat[0]].statValue); //atk
            target.MBEvent?.Invoke(targetedStat[0], entity.statDictionary[targetedStat[0]].MinMaxValue[1]); //atk
            target.MBEvent?.Invoke(targetedStat[1], -entity.statDictionary[targetedStat[1]].statValue); //def
            target.MBEvent?.Invoke(targetedStat[1], entity.statDictionary[targetedStat[1]].MinMaxValue[1]); //def
        }
        
        
    }

    public override void CheckForCondition(Entity entity, EffectHandler target)
    {
        base.CheckForCondition(entity, target);
        //if(entity.statDictionary.ContainsKey(targetedStat[0]))
        //{
        if (entity.GetComponentInParent<PartyHandler>().party.Count == 1)
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
