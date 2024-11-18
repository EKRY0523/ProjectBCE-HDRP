using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StatDisplay : EventHandler
{
    public PlayableCharacterData characterData;
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
        level.text =  "Lv." + characterData.level.lv;
        expText.text = "Exp" + characterData.level.currentExp + "/" + characterData.level.expNeeded;
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Character)
        {
            characterData = GameManager.instance.characterDictionary[(Character)data];
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
