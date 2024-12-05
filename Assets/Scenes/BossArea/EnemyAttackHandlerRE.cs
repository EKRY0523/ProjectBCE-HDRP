using UnityEngine;
using System;
using UnityEngine.AI;
public class EnemyAttackHandlerRE : EventHandler
{
    
    public Entity entity;
    public EnemyAttackConditionRE[] attacks;
    public Transform target;
    public float lastAttackTime, cooldown;
    public bool canAttack;
    public SkillObject placeholder;
    NavMeshAgent agent;

    public override void Awake()
    {
        base.Awake();
        entity = GetComponentInParent<Entity>();
        agent = GetComponentInParent<NavMeshAgent>();

    }
    private void Start()
    {
        //for (int i = 0; i < attacks.Length; i++)
        //{
        //    attacks[i].attack.multiplier = 0;
        //    for (int j = 0; j < attacks[i].UsedStats.Length; j++)
        //    {
        //        attacks[i].multiplier += entity.statDictionary[attacks[i].UsedStats[j]].statValue * attacks[i].dmgMultiplier;
        //    }
        //}
        
    }
    private void Update()
    {
        if (canAttack && target!=null)
        {
            for (int i = 0; i < attacks.Length; i++)
            {
                if(attacks[i].decision.AttackCondition(target,entity) && !attacks[i].inCooldown && !attacks[i].chain)
                {
                    MBEvent?.Invoke(attacks[i].stateID,null);
                    canAttack = false;
                    attacks[i].inCooldown = true;
                    lastAttackTime = Time.time;
                    attacks[i].localAttackTime = Time.time;
                    cooldown = attacks[i].globalCooldown;

                    break;
                }

            }

            for (int i = 0; i < attacks.Length; i++)
            {
                if (Time.time> attacks[i].localAttackTime+ attacks[i].localCooldown)
                {
                    attacks[i].inCooldown = false;
                }
            }

        }

        if (Time.time > lastAttackTime + cooldown)
        {
            
            canAttack = true;
        }
    }

    public void RotateToTarget()
    {
        if(target!=null)
        {
            Vector3 lookAt = target.position - transform.position;
            lookAt.y = 0;
            transform.parent.rotation = Quaternion.LookRotation(lookAt);

        }
    }
    public void SpawnSkillObject(int type)
    {
        placeholder = Instantiate(attacks[type].attack, transform);
        if(attacks[type].followStats)
        {
            for (int i = 0; i < attacks[type].UsedStats.Length; i++)
            {

                placeholder.multiplier = entity.statDictionary[attacks[type].UsedStats[i]].statValue * attacks[type].dmgMultiplier;
            }
        }
        else
        {

            placeholder.multiplier = attacks[type].multiplier;
        }
        placeholder.transform.position = transform.position;

    }

    public void SpawnEffect(GameObject vfx)
    {
        Instantiate(vfx, transform);
    }

    public void ForceExit(Trait trait)
    {
        MBEvent?.Invoke(null, trait);
    }
    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if (data is Transform)
        {
            target = (Transform)data;
        }
    }

    public void MoveCharacter(MovementData moveData)
    {
        MBEvent?.Invoke(null, moveData);

    }

    public void PlayWarning(GameObject warningObj)
    {
        Instantiate(warningObj, transform);
    }
}



[Serializable]
public class EnemyAttackConditionRE
{
    public bool followStats;
    public bool chain;
    public bool inCooldown;
    public Trait stateID;
    public Trait[] UsedStats;
    public EnemyAttackDecision decision;

    public float dmgMultiplier;
    public float multiplier;
    public SkillObject attack;

    public float localAttackTime;
    public float localCooldown;
    public float globalCooldown;


}


public class EnemyAttackDecision : ScriptableObject
{
    public virtual bool AttackCondition(Transform target, Entity entity)
    {
        return false;
    }
}



