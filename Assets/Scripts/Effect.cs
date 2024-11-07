using UnityEngine;
using System.Collections;
public class Effect : ScriptableObject
{
    public enum EffectType
    {
        Passive,Active
    }

    public enum TimeMode
    {
        incremented,realTime
    }

    public EffectType effectType;
    public TimeMode timeMode;
    public float startTime,duration,tick;
    public Trait[] targetedStat;
    public float[] value;
    public virtual void OnInflict(EffectHandler target)
    {

    }

    public virtual void OnStartEffect(EffectHandler target)
    {
        
    }

    public virtual void OnEndEffect(EffectHandler target)
    {

    }

    public virtual void OverTime(EffectHandler target)
    {

    }

    public virtual void PassiveOverTime(Entity entity,EffectHandler target)
    {

    }
    public virtual void PassiveOneShot(Entity entity, EffectHandler target)
    {

    }

    public virtual void CheckForCondition(Entity entity, EffectHandler target)
    {

    }
    //public virtual IEnumerator Overtime(EffectHandler target)
    //{
    //    yield return null;  
    //    //yield return new WaitForSeconds(tick);
    //}

}
