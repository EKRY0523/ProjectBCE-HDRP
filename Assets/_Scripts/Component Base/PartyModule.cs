using UnityEngine;

public class PartyModule : MonoBehaviour
{
    PlayableCharacterData[] characters = new PlayableCharacterData[3];
    PlayableCharacterData currentCharacter;


    private void OnEnable()
    {
        //add Switchevent here
    }

    private void OnDisable()
    {
        //Remove switchevent here
    }

    void SwitchCharacter()
    {

    }

}
