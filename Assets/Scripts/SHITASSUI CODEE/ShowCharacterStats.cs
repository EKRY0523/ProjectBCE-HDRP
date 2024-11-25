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

    private void OnEnable()
    {
        if(charData!=null)
        {
            
        }
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

                HPtext.text = "HP" + charData.statDictionary[HP].MinMaxValue[1] * MathF.Pow(charData.statDictionary[HP].statScaling, charData.level.lv - 1);
                ENGtext.text = "ENG" + charData.statDictionary[ENG].MinMaxValue[1] * MathF.Pow(charData.statDictionary[ENG].statScaling, charData.level.lv - 1);
                ATKtext.text = "ATK" + charData.statDictionary[ATK].MinMaxValue[1] * MathF.Pow(charData.statDictionary[ATK].statScaling, charData.level.lv - 1);
                EATKtext.text = "EATK" + charData.statDictionary[EATK].MinMaxValue[1] * MathF.Pow(charData.statDictionary[EATK].statScaling, charData.level.lv - 1);
                DEFtext.text = "DEF" + charData.statDictionary[DEF].MinMaxValue[1] * MathF.Pow(charData.statDictionary[DEF].statScaling, charData.level.lv - 1);
                EDEFtext.text = "EDEF" + charData.statDictionary[EDEF].MinMaxValue[1] * MathF.Pow(charData.statDictionary[EDEF].statScaling, charData.level.lv - 1);
                SPDtext.text = "SPD" + charData.statDictionary[SPD].MinMaxValue[1] * MathF.Pow(charData.statDictionary[SPD].statScaling, charData.level.lv - 1);

            }

        }



        
    }
}
