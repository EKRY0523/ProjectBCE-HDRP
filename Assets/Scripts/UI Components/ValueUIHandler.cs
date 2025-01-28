using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ValueUIHandler : EventHandler
{
    public Entity Entity;
    public Trait statIndex;
    public Image image;
    public TextMeshProUGUI text;
    public float fill;

    private void Start()
    {
        //fill = Entity.statDictionary[statIndex].statValue/ Entity.statDictionary[statIndex].MinMaxValue[1];
        //image.fillAmount = fill;
        //text.text = Entity.statDictionary[statIndex].statValue + "/" + (Entity.statDictionary[statIndex].MinMaxValue[1] * MathF.Pow(Entity.statDictionary[statIndex].statScaling, Entity.level.lv - 1));
    }

    public override void OnInvoke(Trait ID,object data)
    {
        if(data is PlayableCharacterData)
        {
            Entity = (PlayableCharacterData)data;
            if (Entity.statDictionary.ContainsKey(statIndex))
            {
                OnInvoke(statIndex, Entity.statDictionary[statIndex].statValue);
            }
        }

        if(data is Enemy)
        {
            Entity = (Enemy)data;
            OnInvoke(statIndex, Entity.statDictionary[statIndex].statValue);
        }

        if(ID == statIndex && data is float)
        {
            if(Entity.statDictionary.ContainsKey(ID))
            {
                image.fillAmount = ((float)data) / (Entity.statDictionary[statIndex].MinMaxValue[1]);
                if (text != null)
                {
                    text.text = "<color=black>" + Entity.statDictionary[statIndex].statIdentifier.name + ":</color> " + String.Format("{0:0}/{1:0}", (float)data, (Entity.statDictionary[statIndex].MinMaxValue[1])) ;
                    //text.text = String.Format("{0:0}/{1:0}", (float)data, (Entity.statDictionary[statIndex].MinMaxValue[1] * MathF.Pow(Entity.statDictionary[statIndex].statScaling, Entity.lv - 1)));
                    //text.text = String.Format("{0/1}",(float)data) + "/" + (Entity.statDictionary[statIndex].MinMaxValue[1] * MathF.Pow(Entity.statDictionary[statIndex].statScaling, Entity.level.lv - 1));
                }
            }
            

        }
    }
}
