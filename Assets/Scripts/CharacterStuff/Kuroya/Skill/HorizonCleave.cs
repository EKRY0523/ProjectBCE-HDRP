using UnityEngine;

[CreateAssetMenu(fileName = "HorizonCleave", menuName = "CharacterSkill/Kuroya/Ultimate/Horizon Cleave")]

public class HorizonCleave : UltimateSkill
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
