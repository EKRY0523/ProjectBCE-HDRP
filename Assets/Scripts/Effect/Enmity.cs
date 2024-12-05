using UnityEngine;
[CreateAssetMenu(fileName = "Enmity", menuName = "Effect/Passive/Enmity")]

public class Enmity : Effect
{
    public float placeholder;
    //targeted stat 1 is the target
    //targeted stat 0 is the origin, meaning HP
    public override void OnInflict(EffectHandler target)
    {
        base.OnInflict(target);
        placeholder = 0;
        StatBasedEffect(target.entity, target);
    }
    public override void StatBasedEffect(Entity entity, EffectHandler target)
    {
        base.StatBasedEffect(entity, target);
        entity.statDictionary[targetedStat[1]].statValue -= entity.statDictionary[targetedStat[1]].MinMaxValue[1] * placeholder;
        //target.MBEvent?.Invoke(targetedStat[1], -entity.statDictionary[targetedStat[1]].MinMaxValue[1] * placeholder);
        float test = 1 -(entity.statDictionary[targetedStat[0]].statValue / entity.statDictionary[targetedStat[0]].MinMaxValue[1]);
        placeholder = test;
        entity.statDictionary[targetedStat[1]].statValue += entity.statDictionary[targetedStat[1]].MinMaxValue[1] * placeholder;
        //target.MBEvent?.Invoke(targetedStat[1], entity.statDictionary[targetedStat[1]].MinMaxValue[1] * test);
    }
}
