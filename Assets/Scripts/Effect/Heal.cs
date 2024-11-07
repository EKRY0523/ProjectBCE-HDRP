using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Effect/Heal")]
public class Heal : Effect
{
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
