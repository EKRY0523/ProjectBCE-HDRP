using UnityEngine;
using System;
using System.Collections.Generic;

public class Entity : EventHandler
{
    [SerializeField]public Dictionary<Trait, Stat> statDictionary = new Dictionary<Trait, Stat>();
    public Level level;
    [SerializeField] public List<Stat> stats = new();
    [SerializeField]public Stat[] placeholder;
    public Transform[] skillOriginPoint;

    public override void Awake()
    {
        base.Awake();
    }

    public void handleStat(Trait ID)
    {
        if (statDictionary[ID].statAction.Length > -1)
        {
            for (int i = 0; i < statDictionary[ID].statAction.Length; i++)
            {
                statDictionary[ID].statAction[i].HandleAction(this, statDictionary[ID]);
            }
        }
            
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if (ID != null && data is float)
        {
            if (statDictionary.ContainsKey(ID))
            {
                statDictionary[ID].statValue = (float)data;
                handleStat(ID);
            }
        }

    }
}

