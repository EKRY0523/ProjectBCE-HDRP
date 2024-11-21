using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class StatHandler : EventHandler
{
    //public Dictionary<Trait,Stat> statDictionary = new();
    public Entity entity;
    public bool canReceive;
    public ValueReceived val;
    public override void Awake()
    {
        base.Awake();
        entity = GetComponent<Entity>();
        //statDictionary = entity.statDictionary;
    }

    private void OnEnable()
    {
        canReceive = true;
    }

    private void OnDisable()
    {

        canReceive = false;
    }
    public void ReceiveValue(Trait[] ID,Trait[] counterStat,float value)
    {
        float finalValue = value;
        if(value < 0)
        {
            for (int i = 0; i < counterStat.Length; i++)
            {
                if (entity.statDictionary.ContainsKey(counterStat[i]))
                {
                    finalValue += entity.statDictionary[counterStat[i]].statValue;
                    
                }
            }

            if(finalValue>0)
            {
                finalValue = 0;
            }
        }
        

        for (int i = 0; i < ID.Length; i++)
        {
            if (entity.statDictionary.ContainsKey(ID[i]))
            {
                entity.statDictionary[ID[i]].statValue += finalValue;
                Debug.Log(entity.name + ": " + ID[i].name + finalValue);
                MBEvent?.Invoke(ID[i], entity.statDictionary[ID[i]].statValue);
                if(val!=null)
                {
                    ValueReceived values = Instantiate(val,transform);
                    if(finalValue < 0)
                    {
                        values.dmgText.color= Color.red;
                    }
                    else
                    {
                        values.dmgText.color = Color.green;

                    }
                    values.GetValue(finalValue);

                }
            }
        }
        
    }

    public void ReceiveKnockback(Transform attackingObject,MovementData movementData)
    {
        if(canReceive)
        {
            Vector3 lookAt = attackingObject.position - transform.position;
            lookAt.y = 0;
            transform.rotation = Quaternion.LookRotation(lookAt);

            movementData.MoveCharacter(GetComponent<Rigidbody>());
            MBEvent?.Invoke(ComponentsID[0], null);
            //etComponent<Rigidbody>().AddForce(transform.);
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if (ID != null)
        {
            if (entity.statDictionary.ContainsKey(ID))
            {
                entity.statDictionary[ID].statValue += (float)data;
                //Debug.Log(entity.name + ": " + ID.name + (float)data);
                MBEvent?.Invoke(ID, entity.statDictionary[ID].statValue);

            }
        }

    }

    //public void ResetStat()
    //{
    //    foreach (KeyValuePair<Trait,Stat> stat in statDictionary)
    //    {
    //        //stat.Value.statValue = stat.Value.statValue * MathF.Pow(stat.Value.statScaling, entity.level.lv - 1);
    //        statDictionary[stat.Key].MinMaxValue[1] = statDictionary[stat.Key].MinMaxValue[1] * MathF.Pow(statDictionary[stat.Key].statScaling, entity.level.lv - 1);
    //        statDictionary[stat.Key].statValue = statDictionary[stat.Key].MinMaxValue[1] * MathF.Pow(statDictionary[stat.Key].statScaling, entity.level.lv - 1);
    //        MBEvent?.Invoke(stat.Key, statDictionary[stat.Key].statValue);
    //        //statDictionary[stat].statValue = statDictionary[character.stats[i].statIdentifier].MinMaxValue[1] * MathF.Pow(statDictionary[character.stats[i].statIdentifier].statScaling, level.lv - 1);
    //    }
        
    //}
}
