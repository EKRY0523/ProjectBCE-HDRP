using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Effect/Heal")]
public class Heal : Effect
{
    public bool getStatFromEntity;
    public float DoTperTick;
    public bool offense;
    public override void OnInflict(EffectHandler target)
    {
        base.OnInflict(target);
        
    }
    public override void OnStartEffect(EffectHandler target)
    {
        base.OnStartEffect(target);
    }
    public override void OnEndEffect(EffectHandler target)
    {
        base.OnEndEffect(target);
    }

    public override void OverTime(EffectHandler target)
    {
        base.OverTime(target);

        if (getStatFromEntity)
        {
            for (int i = 0; i < targetedStat.Length; i++)
            {
                if (target.effectDictionary[this].EotTimer >= tick)
                {
                    if(offense)
                    {
                        target.MBEvent?.Invoke(targetedStat[i], -value[i] + -(target.entity.statDictionary[targetedStat[i]].MinMaxValue[1] * DoTperTick));

                    }
                    else
                    {
                        target.MBEvent?.Invoke(targetedStat[i], value[i] + (target.entity.statDictionary[targetedStat[i]].MinMaxValue[1] * DoTperTick));

                    }
                    target.effectDictionary[this].EotTimer = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i < targetedStat.Length; i++)
            {
                if (target.effectDictionary[this].EotTimer >= tick)
                {
                    target.MBEvent?.Invoke(targetedStat[i], value[i]);
                    target.effectDictionary[this].EotTimer = 0;
                }
            }
        }
        
        
    }
}
