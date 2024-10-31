//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.VFX;

//[CreateAssetMenu(fileName = "MinoriUltimate", menuName = "Skills/MinoriUltimate")]
//public class MinoriUlt : CharacterAbility
//{
//    [SerializeField] GameObject UltBeam;
//    public override void SkillUse()
//    {
//        //RaycastHit hit;
//        OldPlayer.instance.startAnim(OldPlayer.instance.playerAnimationData.SkillParameterHash);
//        OldPlayer.instance.rb.AddForce(OldPlayer.instance.rb.transform.forward * -1.5f, ForceMode.VelocityChange);
//        OldPlayer.instance.rb.linearVelocity = Vector3.zero;
//        if (OldPlayer.instance.targetEnemy)
//        {
//            if (Vector3.Distance(OldPlayer.instance.transform.position, OldPlayer.instance.targetEnemy.transform.position) < 15f)
//            {
//                OldPlayer.instance.currentENG -= skillCost;
//                OldPlayer.instance.targetEnemy.GetComponent<Enemy>().stopValue = 0f;

//                Destroy(Instantiate(UltBeam, OldPlayer.instance.targetEnemy.transform), 5f);
//                OldPlayer.instance.StartCoroutine(unfreeze(4f));
//                OldPlayer.instance.StartCoroutine(doDamage(0.1f, 1f));
//                OldPlayer.instance.StartCoroutine(doDamage(0.3f, 1.2f));
//                OldPlayer.instance.StartCoroutine(doDamage(0.5f, 1.35f));
//                OldPlayer.instance.StartCoroutine(doDamage(0.8f, 1.5f));

//            }
//        }

//        //if (Physics.SphereCast(Player.instance.transform.position, 2f, Player.instance.transform.forward, out hit, 10f))
//        //{
//        //    Debug.Log("hi");
//        //    if (hit.collider.CompareTag("Enemy"))
//        //    {

//        //        Destroy(Instantiate(UltBeam, Player.instance.targetEnemy.transform),5f);
//        //    }


//        //}

//    }
//    public override void SkillCooldown(int KeyPressed)
//    {
//        OldPlayer.instance.StartCoroutine(EndCoolDown(this.cooldown, KeyPressed));
//        Debug.Log(this.cooldown);
//    }
//    IEnumerator EndCoolDown(float seconds, int KeyPressed)
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
//    IEnumerator doDamage(float seconds,float damage)
//    {
//        //if (Player.instance.targetEnemy.GetComponent<Enemy>() != null)
//        float finalizedDamage;
//        finalizedDamage = ((OldPlayer.instance.EATK * 5f)*damage) + (OldPlayer.instance.characterHolder.ENG * 3f);
//        OldPlayer.instance.targetEnemy.GetComponent<IDamageable>().TakeDamage(finalizedDamage);
//        yield return new WaitForSeconds(seconds);
//    }
//    IEnumerator unfreeze(float seconds)
//    {
//        yield return new WaitForSeconds(seconds);
//        //Player.instance.comboPassedTime = Time.time;

//        OldPlayer.instance.targetEnemy.GetComponent<Enemy>().stopValue = 1f;
//    }
//}
