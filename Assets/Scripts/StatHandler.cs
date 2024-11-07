using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class StatHandler : EventHandler
{
    public Dictionary<Trait,Stat> statDictionary = new();
    public Entity entity;
    public override void Awake()
    {
        base.Awake();
        entity = GetComponent<Entity>();
        statDictionary = entity.statDictionary;
    }

    public void ReceiveValue(Trait[] ID,Trait[] counterStat,float value)
    {
        float finalValue = value;

        if(value < 0)
        {
            for (int i = 0; i < counterStat.Length; i++)
            {
                if (statDictionary.ContainsKey(counterStat[i]))
                {
                    finalValue += statDictionary[counterStat[i]].statValue;
                }
            }

            if(finalValue>0)
            {
                finalValue = 0;
            }
        }
        

        for (int i = 0; i < ID.Length; i++)
        {
            if (statDictionary.ContainsKey(ID[i]))
            {
                statDictionary[ID[i]].statValue += finalValue;
                Debug.Log(finalValue);
                MBEvent?.Invoke(ID[i], statDictionary[ID[i]].statValue);
            }
        }
        
    }

    public void ReceiveKnockback(Transform attackingObject,MovementData movementData)
    {
        Vector3 lookAt = attackingObject.position - transform.position;
        lookAt.y = 0;
        transform.rotation = Quaternion.LookRotation(lookAt);

        movementData.MoveCharacter(GetComponent<Rigidbody>());

        //etComponent<Rigidbody>().AddForce(transform.);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(statDictionary.ContainsKey(ID))
        {
            statDictionary[ID].statValue += (float)data;
            Debug.Log(statDictionary[ID].statValue);
            MBEvent?.Invoke(ID, statDictionary[ID].statValue);

        }
    }
}
