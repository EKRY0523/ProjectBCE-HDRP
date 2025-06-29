using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;
using System.Collections;
public class CharacterSkill : ScriptableObject
{
    public SkillObject[] skillObject;
    public SkillObjectInstance[] skillInstance;
    public Trait[] key;
    public Cost cost;
    public PlayableCharacterData characterData;
    public StatMultiplier[] statAndMultiplier;
    public int requiredUnlockLevel;
    public string skillName;
    [TextAreaAttribute(10,15)]
    public string skillDescription;
    public Sprite skillIcon;
    public float[] cooldown;
    public MovementData[] movementData;

    public float delayForInstantiate;
    public virtual void OnSetup(PlayableCharacterData character)
    {

    }

    public virtual void OnRemove(PlayableCharacterData character)
    {

    }

    public virtual void OnExecute(InputAction.CallbackContext context)
    {

    }

    public virtual void OnUpdate() //handling the oncharge stuff
    {

    }

    public virtual void SkillMultiplier(int count, Trait[] usedStat)
    {

    }
    public virtual void SkillMultiplier(float stat1)
    {
        
    }
    public virtual void SkillMultiplier(int count,float stat1)
    {

    }

    public virtual void SkillMultiplier(int count, List<float> stats)
    {

    }

    public virtual void OnHold(StatMultiplier[] usedStat)
    {

    }

    public virtual void OnRelease(StatMultiplier[] usedStat)
    {

    }
    public virtual IEnumerator InstantiateWithDelay()
    {
         yield return new WaitForSeconds(delayForInstantiate);
    }
}
[Serializable]
public class SkillObjectInstance
{
    public int instances; // default is 0 unless stated
    public SkillObject[] skillObjects;
}

[Serializable]
public class StatMultiplier
{
    public Trait statIndex;
    public float multiplier;
}
