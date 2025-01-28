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
        float defense = 0;
        if(value < 0)
        {
            for (int i = 0; i < counterStat.Length; i++)
            {
                if (entity.statDictionary.ContainsKey(counterStat[i]))
                {
                    defense += entity.statDictionary[counterStat[i]].statValue;
                    
                }
            }
            float dmgReduction = defense / (defense + 1000);
            finalValue *= (1 - dmgReduction);
        }
        

        for (int i = 0; i < ID.Length; i++)
        {
            if (entity.statDictionary.ContainsKey(ID[i]))
            {
                entity.statDictionary[ID[i]].statValue += finalValue;
                //MBEvent?.Invoke(ID[i], entity.statDictionary[ID[i]].statValue);
                MBEvent?.Invoke(ID[i], entity.statDictionary[ID[i]].statValue);
                if (val!=null)
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
                if (val != null)
                {
                    ValueReceived values = Instantiate(val, transform);
                    
                    values.dmgText.color = Color.red;
                    
                    values.GetValue((float)data);

                }

            }
        }

    }

}
