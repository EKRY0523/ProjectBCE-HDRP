using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class PartyStatusUIHandler : EventHandler
{
    public PartyHandler party;
    public List<PlayableCharacterData> charList = new();
    public CharacterStatusHandler[] subHandler;
    public TextMeshProUGUI[] indexnumber;
    public CharacterStatusHandler mainHandler;

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
        if (data is List<PlayableCharacterData>)
        {
            mainHandler?.OnInvoke(null,party.activeCharacter);
            charList = (List<PlayableCharacterData>)data;
            int subCharacterIndex = 0; 
            for (int i = 0; i < subHandler.Length; i++)
            {
                if (subCharacterIndex < charList.Count)
                {
                    if (charList[subCharacterIndex] == party.activeCharacter)
                    {
                        subCharacterIndex++;
                    }

                    if (subCharacterIndex < charList.Count)
                    {
                        subHandler[i].gameObject.SetActive(true);
                        indexnumber[i].text = (party.party.IndexOf(party.party[subCharacterIndex]) +1).ToString();
                        subHandler[i].OnInvoke(null, party.party[subCharacterIndex]); 
                        subCharacterIndex++;
                    }
                    else
                    {
                        subHandler[i].gameObject.SetActive(false);
                    }
                }
                else
                {
                    subHandler[i].gameObject.SetActive(false); 
                }

            }
        }
    }
}
