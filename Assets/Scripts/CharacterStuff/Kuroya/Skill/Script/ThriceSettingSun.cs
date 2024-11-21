using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ThriceSettingSun", menuName = "CharacterSkill/Kuroya/ThriceSettingSun")]

public class ThriceSettingSun : CharacterSkill
{
    public float[] delayBetweenSlashes;
    public float[] extraMultiplier;
    public override void OnSetup(PlayableCharacterData character)
    {
        base.OnSetup(character);
        characterData = character;
        Debug.Log(characterData);
    }

    public override void OnRemove(PlayableCharacterData character)
    {
        base.OnRemove(character);
    }
    public override void SkillMultiplier(float stat1)
    {
        base.SkillMultiplier(stat1);
        for (int i = 0; i < skillInstance[0].skillObjects.Length; i++)
        {
            skillInstance[0].skillObjects[i].multiplier = stat1 * extraMultiplier[i];

        }
        characterData.StartCoroutine(InstantiateWithDelay());
    }
    public override void OnHold(StatMultiplier[] usedStat)
    {
        float lastMultiplier = 0;
        base.OnHold(usedStat);
        for (int i = 0; i < usedStat.Length; i++)
        {
            Debug.Log(characterData.name);
            lastMultiplier += characterData.statDictionary[statAndMultiplier[i].statIndex].statValue * statAndMultiplier[i].multiplier;

        }
        SkillMultiplier(lastMultiplier);
    }
    public override IEnumerator InstantiateWithDelay()
    {
        for (int i = 0; i < delayBetweenSlashes.Length; i++)
        {
            yield return new WaitForSeconds(delayBetweenSlashes[i]);
            Instantiate(skillInstance[0].skillObjects[i], characterData.transform.parent);

        }
    }
}
