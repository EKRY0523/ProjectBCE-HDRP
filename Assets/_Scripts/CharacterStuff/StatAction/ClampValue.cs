using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Clamp", menuName = "StatAction/Clamp")]
public class ClampValue : StatAction
{
    public override void HandleAction(Entity entity, Stat value)
    {
        entity.statDictionary[value.statIdentifier].statValue = Mathf.Clamp(value.statValue, value.MinMaxValue[0], value.MinMaxValue[1]);
        entity.MBEvent?.Invoke(value.statIdentifier, entity.statDictionary[value.statIdentifier].statValue);
    }
}
