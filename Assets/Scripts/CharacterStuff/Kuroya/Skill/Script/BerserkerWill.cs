using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "Berserker's Will", menuName = "CharacterSkill/Kuroya/Berserker's Will")]
public class BerserkerWill : CharacterSkill
{
    public float additionalMultiplier;
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
        characterData.StartCoroutine(InstantiateWithDelay());
        //Instantiate(skillInstance[0].skillObjects[0], characterData.transform.parent);
        
        //Invoke(nameof(InstantiateWithDelay),delayForInstantiate);
    }
    public override void OnHold(StatMultiplier[] usedStat)
    {
        float lastMultiplier = 0;
        base.OnHold(usedStat);
        for (int i = 0; i < usedStat.Length; i++)
        {
            lastMultiplier += characterData.statDictionary[statAndMultiplier[i].statIndex].statValue * statAndMultiplier[i].multiplier;
            
        }
       SkillMultiplier(lastMultiplier+additionalMultiplier);
    }
    public override IEnumerator InstantiateWithDelay()
    {
        yield return new WaitForSeconds(delayForInstantiate);
        Instantiate(skillInstance[0].skillObjects[0], characterData.transform.parent);
        yield break;
    }

}
