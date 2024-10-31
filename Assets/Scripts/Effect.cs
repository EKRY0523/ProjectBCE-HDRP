using UnityEngine;
using System.Collections;
public class Effect : ScriptableObject
{
    public enum EffectType
    {
        Passive,Active
    }
    public EffectType effectType;
    public float duration,tick;
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
    //public virtual IEnumerator Overtime(EffectHandler target)
    //{
    //    yield return null;  
    //    //yield return new WaitForSeconds(tick);
    //}

}
