using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "Beginner Steps", menuName = "CharacterSkill/BeginnerSteps")]
public class BeginnerSteps : CharacterBasicAttack
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
    public override void AttackCount(int count, StatMultiplier[] statIndex)
    {
        base.AttackCount(count, statIndex);
        float lastMultplier = 0;
        for (int i = 0; i < statIndex.Length; i++)
        {
            lastMultplier += characterData.statDictionary[statIndex[i].statIndex].statValue * (countMultiplier[count]/i);
        }

        SkillMultiplier(count, lastMultplier);
    }

    public override void SkillMultiplier(int count, float stat1)
    {
        base.SkillMultiplier(count, stat1);
        skillObject[count].multiplier = stat1;
        Instantiate(skillObject[count], characterData.transform.parent.position, characterData.transform.parent.rotation);
    }


}
