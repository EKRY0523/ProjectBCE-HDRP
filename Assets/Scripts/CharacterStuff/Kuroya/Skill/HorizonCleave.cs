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

    public override void OnHold(StatMultiplier[] usedStat)
    {
        base.OnHold(usedStat);
    }

    public override void OnRelease(StatMultiplier[] usedStat)
    {
        base.OnRelease(usedStat);
    }
}
