using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowPassive : EventHandler
{
    public Character character;
    public int passiveIndex;

    [Header("Base")]
    public TextMeshProUGUI skillDescription;
    public TextMeshProUGUI skillName;


    public override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        skillName.text = GameManager.instance.characterLoading[character.ID].character.passive[passiveIndex].effectName;
        skillDescription.text = GameManager.instance.characterLoading[character.ID].character.passive[passiveIndex].description;

    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if (data is Character)
        {
            character = (Character)data;
            skillName.text = GameManager.instance.characterLoading[character.ID].character.passive[passiveIndex].effectName;
            skillDescription.text = GameManager.instance.characterLoading[character.ID].character.passive[passiveIndex].description;

            this.gameObject.SetActive(false);
        }
    }
}

