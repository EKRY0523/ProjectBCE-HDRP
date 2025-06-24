using UnityEngine;
using TMPro;
using System.IO;
using System;
public class ShowCharacterStats : EventHandler
{
    public Character character;
    public LevelAndStats stats;
    public Entity charData;
    public Trait HP, ENG, ATK, EATK, DEF, EDEF, SPD;
    public TextMeshProUGUI HPtext, ENGtext, ATKtext, EATKtext, DEFtext, EDEFtext, SPDtext;
    public override void Awake()
    {
        base.Awake();

    }
    public override void OnDestroy()
    {
        base.OnDestroy();   
    }
    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Character)
        {
            character = (Character)data;
            charData = GameManager.instance.characterLoading[character.ID];
            if(charData!=null)
            {
                if(!charData.gameObject.activeSelf)
                {
                    charData.gameObject.SetActive(true);
                    charData.gameObject.SetActive(false); //on off to get the damn fucking script
                }

                HPtext.text = "<color=black>HP </color>" + String.Format("{0:0}",charData.statDictionary[HP].MinMaxValue[1]);
                ENGtext.text = "<color=black>ENG </color>" + String.Format("{0:0}", charData.statDictionary[ENG].MinMaxValue[1]);
                ATKtext.text = "<color=black>ATK </color>" + String.Format("{0:0}", charData.statDictionary[ATK].MinMaxValue[1]);
                EATKtext.text = "<color=black>EATK </color>" + String.Format("{0:0}", charData.statDictionary[EATK].MinMaxValue[1]);
                DEFtext.text = "<color=black>DEF </color>" + String.Format("{0:0}", charData.statDictionary[DEF].MinMaxValue[1]);
                EDEFtext.text = "<color=black>EDEF </color>" + String.Format("{0:0}", charData.statDictionary[EDEF].MinMaxValue[1]);
                //SPDtext.text = "SPD " + String.Format("{0:0}", charData.statDictionary[SPD].MinMaxValue[1]);

            }

        }



        
    }
}
