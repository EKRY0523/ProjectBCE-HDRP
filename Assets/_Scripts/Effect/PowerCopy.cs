using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Copy", menuName = "Effect/Passive/Copy")]

public class PowerCopy : Effect
{
    public Character kuroya;
    public Character ren;
    public override void PassiveOneShot(Entity entity, EffectHandler target)
    {
        base.PassiveOneShot(entity, target);

        if(GameManager.instance.charactersInParty.Contains(GameManager.instance.characterLoading[kuroya.ID]))
        {
            target.MBEvent?.Invoke(targetedStat[0], -entity.statDictionary[targetedStat[0]].statValue);
            target.MBEvent?.Invoke(targetedStat[0], (entity.statDictionary[targetedStat[0]].MinMaxValue[1] * value[0])); //atk
        }
        else
        {
            target.MBEvent?.Invoke(targetedStat[0], -entity.statDictionary[targetedStat[0]].statValue); //atk
            target.MBEvent?.Invoke(targetedStat[0], entity.statDictionary[targetedStat[0]].MinMaxValue[1]); //atk
        }

        if (GameManager.instance.charactersInParty.Contains(GameManager.instance.characterLoading[ren.ID]))
        {
            target.MBEvent?.Invoke(targetedStat[1], -entity.statDictionary[targetedStat[1]].statValue); //EATK
            target.MBEvent?.Invoke(targetedStat[1], (entity.statDictionary[targetedStat[1]].MinMaxValue[1] * value[1])); 
        }
        else
        {
            target.MBEvent?.Invoke(targetedStat[1], -entity.statDictionary[targetedStat[1]].statValue); //Eatk
            target.MBEvent?.Invoke(targetedStat[1], entity.statDictionary[targetedStat[1]].MinMaxValue[1]); //Eatk
        }

        if(GameManager.instance.charactersInParty.Count ==3)
        {
            target.MBEvent?.Invoke(targetedStat[0], 500f);
            target.MBEvent?.Invoke(targetedStat[1], 500f);

            target.MBEvent?.Invoke(targetedStat[2], -entity.statDictionary[targetedStat[2]].statValue);
            target.MBEvent?.Invoke(targetedStat[2], (entity.statDictionary[targetedStat[2]].MinMaxValue[1] * value[2]));
            target.MBEvent?.Invoke(targetedStat[3], -entity.statDictionary[targetedStat[3]].statValue);
            target.MBEvent?.Invoke(targetedStat[3], (entity.statDictionary[targetedStat[3]].MinMaxValue[1] * value[3]));

        }
        else
        {
            target.MBEvent?.Invoke(targetedStat[2], -entity.statDictionary[targetedStat[2]].statValue);
            target.MBEvent?.Invoke(targetedStat[2], entity.statDictionary[targetedStat[2]].MinMaxValue[1]);
            target.MBEvent?.Invoke(targetedStat[3], -entity.statDictionary[targetedStat[3]].statValue);
            target.MBEvent?.Invoke(targetedStat[3], entity.statDictionary[targetedStat[3]].MinMaxValue[1]);
        }


    }

    public override void CheckForCondition(Entity entity, EffectHandler target)
    {
        base.CheckForCondition(entity, target);
        //if(entity.statDictionary.ContainsKey(targetedStat[0]))
        //{
        //if (entity.GetComponentInParent<PartyHandler>().party.Count == 1)
        //{
        //    target.passiveDictionary[this].conditionMet = true;
        //}
        //else
        //{
        //    target.passiveDictionary[this].conditionMet = false;
        //}
        //}

    }

}
