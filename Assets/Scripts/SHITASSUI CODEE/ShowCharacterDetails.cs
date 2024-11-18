using UnityEngine;
using TMPro;
public class ShowCharacterDetails : EventHandler
{
    public TextMeshProUGUI detailsText;
    public Character character;
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        character = (Character)data;
        detailsText.text =  character.characterDetails;

    }
}
