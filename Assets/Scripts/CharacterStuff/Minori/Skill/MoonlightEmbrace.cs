using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "MoonlightEmbrace", menuName = "CharacterSkill/Ultimate/MoonlightEmbrace")]
public class MoonlightEmbrace : CharacterSkill
{
    public override void OnSetup(PlayableCharacterData character)
    {
        base.OnSetup(character);
        characterData = character;
    }
    public override void OnExecute(InputAction.CallbackContext context)
    {
        base.OnExecute(context);

    }

    public override void OnRemove(PlayableCharacterData character)
    {
        base.OnRemove(character);
    }


    public override void SkillMultiplier(float stat1)
    {
        base.SkillMultiplier(stat1);
        skillObject[0].multiplier = stat1;
        Instantiate(skillObject[0], characterData.transform.parent.position, characterData.transform.parent.rotation);
    }

    public override void SkillMultiplier(float stat1, float stat2)
    {
        base.SkillMultiplier(stat1, stat2);
    }

    public override void SkillMultiplier(float stat1, float stat2, float stat3)
    {
        base.SkillMultiplier(stat1, stat2, stat3);
    }
}
