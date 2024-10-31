using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.InputSystem;
public class GameManager : EventHandler
{
    public InputActionReference action;
    public static GameManager instance;
    public DictionaryStorage storage;

    public Dictionary<Character, PlayableCharacterData> characterDictionary = new();
    public Dictionary<int, Character> characterIdentifier = new();

    public List<PlayableCharacterData> characters; // use this mainly
    public List<PlayableCharacterData> UnlockedCharacters = new(); //partysetup needs this
    public SaveProgress progress;
    public PartyHandler party;

    public PlayableCharacterData FirstCharacter;
    public override void Awake()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characterDictionary.Add(characters[i].character,characters[i]);
            characterIdentifier.Add(characters[i].character.ID, characters[i].character);
            if (characters[i].unlocked)
            {
                UnlockedCharacters.Add(characters[i]);
            }
        }

        action.action.performed += (ctx) => SaveData();

        instance = this;
        //LoadData();

        base.Awake();
    }

    public void SaveData()
    {
        SaveProgress currentProgress = new SaveProgress();

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].unlocked)
            {
                currentProgress.unlockedCharacterList.Add(i);
            }
        }

        for (int i = 0; i < party.characterList.Count; i++)
        {
            currentProgress.currentPartySetup.Add(party.characterList[i].character.ID);
        }
        

        progress = currentProgress;

        string json = JsonUtility.ToJson(currentProgress, true);
        File.WriteAllText(Application.dataPath + "/SaveFile.json", json);
    }

    public void LoadData()
    {
        if(File.Exists(Application.dataPath + "/SaveFile.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/SaveFile.json");

            progress = JsonUtility.FromJson<SaveProgress>(json);

            for (int i = 0; i < progress.unlockedCharacterList.Count; i++)
            {
                if (UnlockedCharacters.Contains(characters[progress.unlockedCharacterList[i]]))
                {
                    //Debug.Log(characters[progress.unlockedCharacterList[i]].name);
                }
                else
                {
                    UnlockedCharacters.Add(characters[progress.unlockedCharacterList[i]]);
                }
            }

            for (int i = 0; i < progress.currentPartySetup.Count; i++)
            {
                MBEvent?.Invoke(null, characterDictionary[characterIdentifier[progress.currentPartySetup[i]]]);
                //party.characterList.Add(Instantiate(characterDictionary[characterIdentifier[progress.currentPartySetup[i]]],party.transform));
            }
        }
        else
        {
            SaveData();
        }
    }
    public bool CheckExistData()
    {
        if (File.Exists(Application.dataPath + "/SaveFile.json"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveCharacterData(PlayableCharacterData characterData,Character character)
    {
        characterDictionary[character].stats = characterData.stats;
        characterDictionary[character].level = characterData.level;

        LevelAndStats data = new LevelAndStats();
        data.level = characterDictionary[character].level;

        for (int i = 0; i < characterDictionary[character].stats.Count; i++)
        {
            data.statID.Add(characterDictionary[character].stats[i].statIdentifier.key);
            data.stats.Add(characterDictionary[character].stats[i]);
        }


        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/CharacterSaveFile/" + character.name +".json", json);
    }

    public void LoadCharacterData(PlayableCharacterData characterData,Character character)
    {
        if (File.Exists(Application.dataPath + "/CharacterSaveFile/" + character.name + ".json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/CharacterSaveFile/" + character.name + ".json");
            LevelAndStats data = new LevelAndStats();
            data = JsonUtility.FromJson<LevelAndStats>(json);
            for (int i = 0; i < data.statID.Count; i++)
            {
                characterDictionary[character].stats[i].statIdentifier = DictionaryStorage.TraitDictionary[characterDictionary[character].character.stats[i].statIdentifier.key];
                characterDictionary[character].stats[i].statValue = data.stats[i].statValue;
                characterDictionary[character].stats[i].MinMaxValue = data.stats[i].MinMaxValue;
            }

            characterDictionary[character].level = data.level;
            characterData.stats = characterDictionary[character].stats;
            characterData.level = data.level;
        }
        else
        {
            SaveCharacterData(characterData, character);
        }
    }

    public bool CheckExistCharacter(Character character)
    {
        if (File.Exists(Application.dataPath + "/CharacterSaveFile/" + character.name + ".json"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
    }
}

[Serializable]
public class SaveProgress
{
    public List<int> unlockedCharacterList = new();
    public List<int> currentPartySetup = new();
}

[Serializable]
public class LevelAndStats
{
    public Level level;
    [SerializeField] public List<int> statID = new();
    public List<Stat> stats = new();
}