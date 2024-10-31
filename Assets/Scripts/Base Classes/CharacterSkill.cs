using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;
public class CharacterSkill : ScriptableObject
{
    public SkillObject[] skillObject;
    public SkillObjectInstance[] skillInstance;
    public Trait[] key;
    public PlayableCharacterData characterData;
    public Trait[] statIndex;
    public int requiredUnlockLevel;
    public string skillName;
    public string skillDescription;
    public Image skillIcon;
    public float[] cooldown;
    public MovementData[] movementData;
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
    public virtual void SkillMultiplier(float stat1,float stat2)
    {

    }
    public virtual void SkillMultiplier(float stat1, float stat2,float stat3)
    {

    }

}
[Serializable]
public class SkillObjectInstance
{
    public int instances; // default is 0 unless stated
    public SkillObject[] skillObjects;
}
