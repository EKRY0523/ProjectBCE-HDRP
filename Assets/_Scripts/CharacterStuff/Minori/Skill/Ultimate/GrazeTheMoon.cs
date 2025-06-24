using UnityEngine;

[CreateAssetMenu(fileName = "GrazeTheMoon", menuName = "CharacterSkill/Minori/Ultimate/GrazeTheMoon")]
public class GrazeTheMoon : UltimateSkill
{
   

    public float[] extraMultiplier;
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
        for (int i = 0; i < skillInstance[0].skillObjects.Length; i++)
        {
            skillInstance[0].skillObjects[i].multiplier = stat1 * extraMultiplier[i];
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
}
