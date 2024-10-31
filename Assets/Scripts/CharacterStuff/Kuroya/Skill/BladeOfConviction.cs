using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Blade Of Conviction", menuName = "CharacterSkill/Blade Of Conviction")]
public class BladeOfConviction : CharacterBasicAttack
{
    public override void OnSetup(PlayableCharacterData character)
    {
        base.OnSetup(character);
        characterData = character;
    }

    public override void OnRemove(PlayableCharacterData character)
    {
        base.OnRemove(character);
    }
    public override void AttackCount(int count, Trait[] statIndex)
    {
        base.AttackCount(count,statIndex);
        float lastMultplier = 0;
        for (int i = 0; i < statIndex.Length; i++)
        {
            lastMultplier += characterData.statDictionary[statIndex[i]].statValue;
            SkillMultiplier(count, lastMultplier);
        }
    }

    public override void SkillMultiplier(int count, float stat1)
    {
        base.SkillMultiplier(count, stat1);
        for (int i = 0; i < skillInstance[count].skillObjects.Length; i++)
        {
            skillInstance[count].skillObjects[i].multiplier = stat1/ skillInstance[count].skillObjects.Length;
        }
        
        //Instantiate(skillObject[count], characterData.transform.parent.position, characterData.transform.parent.rotation);
    }
}
