using UnityEngine;
using System.Collections.Generic;

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

    public void ReceiveValue(Trait[] ID,float value)
    {
        for (int i = 0; i < ID.Length; i++)
        {
            if (statDictionary.ContainsKey(ID[i]))
            {
                statDictionary[ID[i]].statValue += value;
                MBEvent?.Invoke(ID[i], statDictionary[ID[i]].statValue);
                Debug.Log(statDictionary[ID[i]].statValue);
            }
        }
        
    }

    

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        statDictionary[ID].statValue += (float)data;
        Debug.Log(statDictionary[ID].statValue);
        MBEvent?.Invoke(ID, statDictionary[ID].statValue);
    }
}
