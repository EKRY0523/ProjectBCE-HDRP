using UnityEngine;
using System;
public class Enemy : Entity
{
    public Statemachine statemachine;
    public float givenExp;
    public override void Awake()
    {
        base.Awake();
        statemachine = GetComponent<Statemachine>();
        for (int i = 0; i < stats.Count; i++)
        {
            statDictionary.Add(stats[i].statIdentifier, stats[i]);
            statDictionary[stats[i].statIdentifier].statValue = statDictionary[stats[i].statIdentifier].MinMaxValue[1] * MathF.Pow(statDictionary[stats[i].statIdentifier].statScaling,level.lv - 1);
        }
    }
    private void Start()
    {

        MBEvent?.Invoke(null, this);
    }
}
