//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(fileName = "MinoriBasic", menuName = "Attacks/MinoriBasic")]
//public class MinoriBasic : BasicAttacks
//{   
//    public override void attack1()
//    {
//        OldPlayer.instance.startAnim(OldPlayer.instance.playerAnimationData.Chain1ParameterHash);
//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.Chain2ParameterHash);
//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.Chain3ParameterHash);
//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.SkillParameterHash);


       

//        OldPlayer.instance.rb.linearVelocity = Vector3.zero;
//        OldPlayer.instance.rb.AddForce(OldPlayer.instance.rb.transform.forward * 2f, ForceMode.VelocityChange);
//        if(OldPlayer.instance.targetEnemy)
//        {
//            if (Vector3.Distance(OldPlayer.instance.transform.position, OldPlayer.instance.targetEnemy.transform.position) < 2f)
//            {
//                float finalizedDamage;
//                finalizedDamage = (OldPlayer.instance.ATK * 2f) + (OldPlayer.instance.characterHolder.STR * 0.5f);
//                OldPlayer.instance.targetEnemy.GetComponent<IDamageable>().TakeDamage(finalizedDamage);
//                OldPlayer.instance.currentENG += regenValue * 1;
//            }
//        }
       
//        OldPlayer.instance.StartCoroutine(damageEnemy(0.5f));

//    }

//    public override void attack2()
//    {
//        OldPlayer.instance.startAnim(OldPlayer.instance.playerAnimationData.Chain2ParameterHash);
//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.Chain1ParameterHash);
//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.Chain3ParameterHash);

//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.SkillParameterHash);
//        float takeDamage = damage * 1.2f;
//        OldPlayer.instance.rb.AddForce(OldPlayer.instance.rb.transform.forward * 2.5f, ForceMode.VelocityChange);
//        OldPlayer.instance.rb.linearVelocity = Vector3.zero;

//        if (OldPlayer.instance.targetEnemy)
//        {
//            if (Vector3.Distance(OldPlayer.instance.transform.position, OldPlayer.instance.targetEnemy.transform.position) < 2f)
//            {
//                float finalizedDamage;
//                finalizedDamage = (OldPlayer.instance.ATK * 2.5f) + (OldPlayer.instance.characterHolder.STR * 0.5f);
//                OldPlayer.instance.targetEnemy.GetComponent<IDamageable>().TakeDamage(finalizedDamage);
//                OldPlayer.instance.currentENG += regenValue * 1.3f;
//            }
//        }
//        OldPlayer.instance.StartCoroutine(damageEnemy(0.5f));
//    }

//    public override void attack3()
//    {
//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.Chain1ParameterHash);
//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.Chain2ParameterHash);
//        OldPlayer.instance.startAnim(OldPlayer.instance.playerAnimationData.Chain3ParameterHash);

//        OldPlayer.instance.stopAnim(OldPlayer.instance.playerAnimationData.SkillParameterHash);
//        float takeDamage = damage * 2f;
//        OldPlayer.instance.rb.AddForce(OldPlayer.instance.rb.transform.forward * 3f, ForceMode.VelocityChange);
//        OldPlayer.instance.rb.linearVelocity = Vector3.zero;
//        if (OldPlayer.instance.targetEnemy)
//        {
//            if (Vector3.Distance(OldPlayer.instance.transform.position, OldPlayer.instance.targetEnemy.transform.position) < 2f)
//            {
//                float finalizedDamage;
//                finalizedDamage = (OldPlayer.instance.ATK * 3f) + (OldPlayer.instance.characterHolder.STR * 0.5f);
//                OldPlayer.instance.targetEnemy.GetComponent<IDamageable>().TakeDamage(finalizedDamage);
//                OldPlayer.instance.currentENG += regenValue * 2f;
//            }
//        }
//        OldPlayer.instance.StartCoroutine(damageEnemy(0.5f));
//    }

    

//    IEnumerator damageEnemy(float seconds)
//    {
        
//        yield return new WaitForSeconds(seconds);
//        OldPlayer.instance.input.playerActions.Attack.Enable();
//        OldPlayer.instance.input.playerActions.Skill1.Enable();
//        OldPlayer.instance.input.playerActions.Skill2.Enable();
//        OldPlayer.instance.input.playerActions.Ultimate.Enable();
//        //Debug.Log("damaged at" + Time.time);
        
//    }

//}
