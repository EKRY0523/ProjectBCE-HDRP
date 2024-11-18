using UnityEngine;
using System;
public class EnemyAttackHandler : EventHandler
{
    public Entity entity;
    public EnemyAttackCondition[] attacks;
    public Transform target;

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
                attacks[i].attack.multiplier += entity.statDictionary[attacks[i].UsedStats[j]].statValue;
            }
        }
    }
    private void Update()
    {
        if(target!=null)
        {
            for (int i = 0; i < attacks.Length; i++)
            {
                if(Vector3.Distance(transform.position,target.position) <= attacks[i].range)
                {
                    MBEvent?.Invoke(attacks[i].stateID,null);
                }
            }
        }
        
    }

    public void RotateToTarget()
    {
        Vector3 lookAt = target.position - transform.position;
        lookAt.y = 0;
        transform.parent.rotation = Quaternion.LookRotation(lookAt);
    }
    public void SpawnSkillObject(int type)
    {
        Instantiate(attacks[type].attack, transform);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Transform)
        {
            target = (Transform)data;
        }
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
}
