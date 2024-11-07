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
[Serializable]
public class PassiveHandling
{
    public Effect effect;
    public bool conditionMet;
}
public class EffectHandler : EventHandler
{
    public Entity entity;
    public Effect[] Immune;
    public List<EffectHandling> InflictedEffects = new();

    public List<PassiveHandling> passive = new();

    public Dictionary<Effect, EffectHandling> effectDictionary = new();
    public Dictionary<Effect,PassiveHandling> passiveDictionary = new();
    public PartyHandler party;

    public override void Awake()
    {
        base.Awake();
        entity = GetComponent<Entity>();
        if(GetComponent<PartyHandler>())
        {
            party = GetComponent<PartyHandler>();
        }

        for (int i = 0; i < passive.Count; i++)
        {
            if (!passiveDictionary.ContainsKey(passive[i].effect))
            {
                PassiveHandling newPassive = new();
                newPassive.effect = passive[i].effect;
                passiveDictionary.Add(passive[i].effect, newPassive);
                Debug.Log(passiveDictionary[passive[i].effect].effect.name);
                passive[i].effect.PassiveOneShot(entity, this);
            }

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

        for (int i = 0; i < passive.Count; i++)
        {
            passiveDictionary[passive[i].effect].effect.CheckForCondition(entity, this);
            if (passiveDictionary[passive[i].effect].conditionMet)
            {
                passiveDictionary[passive[i].effect].effect.PassiveOverTime(entity, this);
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
