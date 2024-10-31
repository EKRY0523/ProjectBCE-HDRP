using UnityEngine;
using System;
using System.Collections.Generic;
public class PartyHandler : EventHandler
{
    [SerializeField]protected PlayerInput playerInput;
    public List<PlayableCharacterData> characterList = new();
    public PlayableCharacterData activeCharacter;

    public Action[] test;

    public override void Awake()
    {
        base.Awake();

        if(GameManager.instance!=null)
        {
            if(GameManager.instance.CheckExistData())
            {
                GameManager.instance.LoadData();
            }
            else
            {
                if (characterList.Count <= 1)
                {
                    characterList.Add(Instantiate(GameManager.instance.UnlockedCharacters[0], transform));
                    
                }
                GameManager.instance.SaveData();
            }

        }

        playerInput.SwitchOne += () => OnCharacterChange(0);
        playerInput.SwitchTwo += () => OnCharacterChange(1);
        playerInput.SwitchThree += () => OnCharacterChange(2);

        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].gameObject.SetActive(false);
        }

        activeCharacter = characterList[0];
        activeCharacter.gameObject.SetActive(true);
        MBEvent?.Invoke(null, activeCharacter);
    }
    private void Start()
    {
        MBEvent?.Invoke(null, activeCharacter);
    }
    public void OnCharacterChange(int index)
    {

        if(index < characterList.Count)
        {
            MBEvent?.Invoke(null, activeCharacter);
            activeCharacter.gameObject.SetActive(false);
            activeCharacter = characterList[index];
            activeCharacter.gameObject.SetActive(true);
        }
        
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);

        if(data is PlayableCharacterData)
        {
            PlayableCharacterData character = (PlayableCharacterData)data;

            characterList.Add(Instantiate(character,transform));
            
        }

        if(data is List<PlayableCharacterData>)
        {
            List<PlayableCharacterData> tempData = (List<PlayableCharacterData>)data;

            characterList.Clear();
            for (int i = 0; i < tempData.Count; i++)
            {
                if(tempData[i]!=null)
                {
                    characterList.Add(Instantiate(tempData[i], transform));
                    characterList[i].gameObject.SetActive(false);

                }
            }
            activeCharacter = characterList[0];
            activeCharacter.gameObject.SetActive(true);
            MBEvent?.Invoke(null, activeCharacter);
            GameManager.instance.SaveData();
        }
    }
}
