using UnityEngine;

[CreateAssetMenu(fileName = "BuffAttack", menuName = "Effect/BuffAttack")]
public class BuffAttack : Effect
{
    public bool getStatFromEntity;
    public float[] extraMultiplierFromStat;
    public bool offense;
    public override void OnEndEffect(EffectHandler target)
    {
        if (getStatFromEntity)
        {
            for (int i = 0; i < targetedStat.Length; i++)
            {
                target.MBEvent?.Invoke(targetedStat[i], -(value[i] + (target.entity.statDictionary[targetedStat[i]].MinMaxValue[1] * extraMultiplierFromStat[i])));
            }
        }
        else
        {
            for (int i = 0; i < targetedStat.Length; i++)
            {
                target.MBEvent?.Invoke(targetedStat[i], -value[i]);
            }
        }
    }

    public override void OnInflict(EffectHandler target)
    {
        base.OnInflict(target);
        target.effectDictionary[this].startTime = Time.time;
        target.effectDictionary[this].duration = duration;
        if(getStatFromEntity)
        {
            if(offense)
            {
                for (int i = 0; i < targetedStat.Length; i++)
                {
                    target.MBEvent?.Invoke(targetedStat[i], -value[i] + -(target.entity.statDictionary[targetedStat[i]].MinMaxValue[1] * extraMultiplierFromStat[i]));
                }

            }
            else
            {

                for (int i = 0; i < targetedStat.Length; i++)
                {
                    target.MBEvent?.Invoke(targetedStat[i], value[i] + (target.entity.statDictionary[targetedStat[i]].MinMaxValue[1] * extraMultiplierFromStat[i]));
                }
            }
        }
        else
        {
            for (int i = 0; i < targetedStat.Length; i++)
            {
                target.MBEvent?.Invoke(targetedStat[i], value[i]);
            }
        }
        
    }

    public override void OnStartEffect(EffectHandler target)
    {
        base.OnStartEffect(target);
        
    }

    public override void OverTime(EffectHandler target)
    {
        base.OverTime(target);
    }
}
