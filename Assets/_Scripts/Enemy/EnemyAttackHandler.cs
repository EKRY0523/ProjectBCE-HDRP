using UnityEngine;
using System;
public class EnemyAttackHandler : EventHandler
{
    public Entity entity;
    public EnemyAttackCondition[] attacks;
    public Transform target;
    public float lastAttackTime,cooldown;
    public bool canAttack;
    public SkillObject placeholder;
    public override void Awake()
    {
        base.Awake();
        entity = GetComponentInParent<Entity>();
        
    }
    private void Start()
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].attack.multiplier = 0;
            for (int j = 0; j < attacks[i].UsedStats.Length; j++)
            {
                attacks[i].multiplier += entity.statDictionary[attacks[i].UsedStats[j]].statValue;
            }
        }
    }
    private void Update()
    {
        if(canAttack)
        {
            if (target != null)
            {
                for (int i = 0; i < attacks.Length; i++)
                {
                    if(!attacks[i].inCooldown)
                    {
                        if (attacks[i].moreThanRange && Vector3.Distance(transform.position, target.position) > attacks[i].range ||
                            !attacks[i].moreThanRange && Vector3.Distance(transform.position, target.position) <= attacks[i].range)
                        {

                                MBEvent?.Invoke(attacks[i].stateID, null);
                                attacks[i].inCooldown = true;
                                attacks[i].lastTimeUsedThisAttack = Time.time;
                                canAttack = false;
                                lastAttackTime = Time.time;
                                cooldown = attacks[i].cooldown;
                            break;
                            
                        }

                    }
                }
            }
        }
        for (int i = 0; i < attacks.Length; i++)
        {
            if (Time.time > attacks[i].lastTimeUsedThisAttack + attacks[i].localCooldown)
            {
                attacks[i].inCooldown = false;
            }

        }

        if (Time.time > lastAttackTime+cooldown)
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
        placeholder.multiplier = attacks[type].multiplier;
        placeholder.transform.position = transform.position;

    }

    public void ForceExit(Trait trait)
    {
        MBEvent?.Invoke(null, trait);
    }
    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Transform)
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
        Instantiate(warningObj,transform);
    }
}



[Serializable]
public class EnemyAttackCondition
{
    public Trait stateID;
    public Trait[] UsedStats;
    public float range;
    public float multiplier;
    public SkillObject attack;

    public float lastTimeUsedThisAttack;
    public float localCooldown;

    public bool inCooldown;
    public float cooldown;
    public bool moreThanRange;

}
