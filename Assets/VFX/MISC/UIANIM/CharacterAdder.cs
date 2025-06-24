using UnityEngine;

public class CharacterAdder : MonoBehaviour
{
    public PlayableCharacterData character;
    public UnlockCharacterUIHandler uihandler;
    private void OnEnable()
    {
        if(!GameManager.instance.characterLoading[character.character.ID].unlocked)
        {
            character.OnUnlock();
            GameManager.instance.characterLoading[character.character.ID].unlocked = true;
        }

        uihandler.characterData = character;
        uihandler.image = character.character.poseImage;
        uihandler.slot.texture = uihandler.image;
        uihandler.description.text = character.character.characterName + " has joined the battle";
        uihandler.gameObject.SetActive(true);
    }
}
