//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(fileName = "MinoriSkill2", menuName = "Skills/MinoriSkill2")]
//public class MinoriSkill2 : CharacterAbility
//{
//    public override void SkillUse()
//    {
       
//        OldPlayer.instance.startAnim(Player.playerAnimationData.SkillParameterHash);
//        OldPlayer.instance.rb.AddForce(OldPlayer.instance.rb.transform.forward * 3f, ForceMode.VelocityChange);
//        OldPlayer.instance.rb.linearVelocity = Vector3.zero;

//        if (OldPlayer.instance.targetEnemy)
//        {
//            if (Vector3.Distance(OldPlayer.instance.transform.position, OldPlayer.instance.targetEnemy.transform.position) < 4f)
//            {
//                OldPlayer.instance.currentENG -= skillCost;
//                float finalizedDamage;
//                finalizedDamage = (OldPlayer.instance.ATK * 5f) + (OldPlayer.instance.characterHolder.STR * 0.8f);
//                //OldPlayer.instance.targetEnemy.GetComponent<IDamageable>().TakeDamage(finalizedDamage);
//            }
//        }
//    }

//    public override void SkillCooldown(int KeyPressed)
//    {
//        OldPlayer.instance.StartCoroutine(EndCoolDown(this.cooldown,KeyPressed));
//        Debug.Log(this.cooldown);
//    }

//    IEnumerator EndCoolDown(float seconds,int KeyPressed)
//    {

//        yield return new WaitForSeconds(seconds);
//        if (KeyPressed == 1)
//        {
//            OldPlayer.instance.input.playerActions.Skill1.Enable();
//        }
//        else if (KeyPressed == 2)
//        {
//            OldPlayer.instance.input.playerActions.Skill2.Enable();
//        }
//        else if (KeyPressed == 3)
//        {
//            OldPlayer.instance.input.playerActions.Ultimate.Enable();
//        }

//    }
//}
