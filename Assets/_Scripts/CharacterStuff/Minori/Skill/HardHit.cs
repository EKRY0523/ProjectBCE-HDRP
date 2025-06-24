using System.Collections;
using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "HardHit", menuName = "CharacterSkill/Minori/HardHit")]
public class HardHit : CharacterSkill
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
    public override void SkillMultiplier(float stat1)
    {
        base.SkillMultiplier(stat1);
        skillInstance[0].skillObjects[0].multiplier = stat1;
        if(delayForInstantiate==0)
        {

            Instantiate(skillInstance[0].skillObjects[0], characterData.transform.parent);
        }
        else
        {
            characterData.StartCoroutine(InstantiateWithDelay());
        }
    }
    public override void OnHold(StatMultiplier[] usedStat)
    {
        float lastMultiplier = 0;
        base.OnHold(usedStat);
        for (int i = 0; i < usedStat.Length; i++)
        {
            lastMultiplier += characterData.statDictionary[statAndMultiplier[i].statIndex].statValue * statAndMultiplier[i].multiplier;

        }
        SkillMultiplier(lastMultiplier);
    }

    public override IEnumerator InstantiateWithDelay()
    {
        yield return new WaitForSeconds(delayForInstantiate);
        Instantiate(skillInstance[0].skillObjects[0], characterData.transform.parent);
    }
}
