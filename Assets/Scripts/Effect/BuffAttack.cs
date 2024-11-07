using UnityEngine;

[CreateAssetMenu(fileName = "BuffAttack", menuName = "Effect/BuffAttack")]
public class BuffAttack : Effect
{
    public override void OnEndEffect(EffectHandler target)
    {
        for (int i = 0; i < targetedStat.Length; i++)
        {
            target.MBEvent?.Invoke(targetedStat[i], -value[i]);   
        }
    }

    public override void OnInflict(EffectHandler target)
    {
        base.OnInflict(target);
        target.effectDictionary[this].startTime = Time.time;
        target.effectDictionary[this].duration = duration;
        for (int i = 0; i < targetedStat.Length; i++)
        {
            target.MBEvent?.Invoke(targetedStat[i], value[i]);
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
