using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HpValueHandler : EventHandler
{
    public StatHandler dataReference;
    public Trait statName;
    public Image image;
    public float fill;

    private void Start()
    {
        Debug.Log(dataReference.statDictionary[statName].statValue);
        fill = dataReference.statDictionary[statName].statValue/ dataReference.statDictionary[statName].MinMaxValue[1];
        image.fillAmount = fill;
    }

    public override void OnInvoke(Trait ID,object data)
    {
        if(data is float)
        {
            image.fillAmount =  ((float)data)/ dataReference.statDictionary[statName].MinMaxValue[1];
        }
    }
}
