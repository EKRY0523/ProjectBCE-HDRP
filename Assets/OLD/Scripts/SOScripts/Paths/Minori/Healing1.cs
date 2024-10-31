using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healing1", menuName = "Skills/Healing1")]
public class Healing1 : CharacterAbility
{
    public override void SkillUse()
    {

        OldPlayer.instance.startAnim(OldPlayer.instance.playerAnimationData.SkillParameterHash);
        OldPlayer.instance.rb.linearVelocity = Vector3.zero;
        OldPlayer.instance.currentHP += (100 +(OldPlayer.instance.characterHolder.VIT * 4.5f) + (OldPlayer.instance.characterHolder.MTL * 0.5f));

    }

    public override void SkillCooldown(int KeyPressed)
    {
        OldPlayer.instance.StartCoroutine(EndCoolDown(this.cooldown, KeyPressed));
        Debug.Log(this.cooldown);
    }

    IEnumerator EndCoolDown(float seconds, int KeyPressed)
    {

        yield return new WaitForSeconds(seconds);
        if (KeyPressed == 1)
        {
            OldPlayer.instance.input.playerActions.Skill1.Enable();
        }
        else if (KeyPressed == 2)
        {
            OldPlayer.instance.input.playerActions.Skill2.Enable();
        }
        else if (KeyPressed == 3)
        {
            OldPlayer.instance.input.playerActions.Ultimate.Enable();
        }

    }
}
