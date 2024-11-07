using UnityEngine;
using UnityEngine.UI;
public class CharacterIconSwitch : EventHandler
{
    public Image image;
    public PlayableCharacterData characterData;
    public override void Awake()
    {
        base.Awake();
    }
    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is PlayableCharacterData)
        {
            characterData = (PlayableCharacterData)data;
            image.sprite = characterData.character.iconimage;
        }
    }
}

