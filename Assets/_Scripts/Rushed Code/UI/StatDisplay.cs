using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class StatDisplay : EventHandler
{
    public PlayableCharacterData characterData;
    Character character;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI level;
    public TextMeshProUGUI expText;
    public Image exp;
    public override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        characterName.text = characterData.character.characterName;
        level.text =  "Lv." + characterData.lv;
        expText.text = "Exp " + String.Format("{0:0}/{1:0}",characterData.currentEXP , characterData.ExpNeeded);
        exp.fillAmount = characterData.currentEXP/characterData.ExpNeeded;
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Character)
        {
            character = (Character)data;
            characterData = GameManager.instance.characterLoading[character.ID];
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
