using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class EffectHandling
{
    public Effect effect;
    public float startTime;
    public float duration;
    public float EotTimer;
}

public class EffectHandler : EventHandler
{
    public Effect[] Immune;
    public List<EffectHandling> InflictedEffects = new();
    public Dictionary<Effect, EffectHandling> effectDictionary = new();
    public PartyHandler party;

    public override void Awake()
    {
        base.Awake();
        if(GetComponent<PartyHandler>())
        {
            party = GetComponent<PartyHandler>();
        }
    }
    public void OnAddEffect(Effect effect)
    {
        if(!effectDictionary.ContainsKey(effect))
        {
            EffectHandling newEffect = new();
            newEffect.effect = effect;
            InflictedEffects.Add(newEffect);
            effectDictionary.Add(effect,newEffect);

            newEffect.effect.OnInflict(this);
        }
    }


    private void Update()
    {
        for (int i = 0; i < InflictedEffects.Count; i++)
        {
            if(InflictedEffects[i].effect.timeMode == Effect.TimeMode.incremented)
            {
                InflictedEffects[i].duration += Time.deltaTime;
                InflictedEffects[i].EotTimer += Time.deltaTime;

                effectDictionary[InflictedEffects[i].effect].effect?.OverTime(this);
                if (InflictedEffects[i].duration >= InflictedEffects[i].effect.duration)
                {
                    effectDictionary[InflictedEffects[i].effect].effect.OnEndEffect(this);
                    effectDictionary.Remove(InflictedEffects[i].effect);
                    InflictedEffects.RemoveAt(i);
                }
            }
            else
            {
                if (Time.time >= InflictedEffects[i].startTime + InflictedEffects[i].duration)
                {
                    effectDictionary[InflictedEffects[i].effect].effect.OnEndEffect(this);
                    effectDictionary.Remove(InflictedEffects[i].effect);
                    InflictedEffects.RemoveAt(i);
                }
            }

            
        }
    }

    public void OnEndEffect(Effect effect)
    {
        //if (InflictedEffects.Contains(effect))
        //{
        //    InflictedEffects.Remove(effect);
        //    effect.OnEndEffect(this);
        //}
    }

}
