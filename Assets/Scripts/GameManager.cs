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
    public List<PlayableCharacterData> charactersInParty = new();

    public GameStoryData gameData;
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
            charactersInParty.Clear();
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
                charactersInParty.Add(characterDictionary[characterIdentifier[progress.currentPartySetup[i]]]);
                //MBEvent?.Invoke(null, characterDictionary[characterIdentifier[progress.currentPartySetup[i]]]);
                //party.characterList.Add(Instantiate(characterDictionary[characterIdentifier[progress.currentPartySetup[i]]],party.transform));
            }
            SOEvent[0].globalEvent?.Invoke(charactersInParty);
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

        LevelAndStats data = new ();
        data.level = characterDictionary[character].level;

        for (int i = 0; i < characterDictionary[character].stats.Count; i++)
        {

            data.stats.Add(characterDictionary[character].stats[i]);
            data.statID.Add(characterDictionary[character].stats[i].statIdentifier.key);
            data.currentStatValue.Add(Mathf.Clamp(characterDictionary[character].stats[i].statValue, characterDictionary[character].stats[i].MinMaxValue[0], characterDictionary[character].stats[i].MinMaxValue[1] * MathF.Pow(characterDictionary[character].stats[i].statScaling, characterDictionary[character].level.lv -1)));
           
        }

        for (int i = 0; i < character.BasicAttack.Length; i++)
        {
            if(character.BasicAttack[i] == characterData.basic.basicAttack)
            {
                data.basicAttack = i;
                //data.skill.basicAttack = i;
            }
        }

        for (int i = 0; i < character.Skills.Length; i++)
        {
            if (character.Skills[i] == characterData.firstSkill.Skill1)
            {
                data.skill1 = i;

                //data.skill.skill1 = i;
            }
            else if (character.Skills[i] == characterData.secondSkill.Skill2)
            {
                //data.skill.skill2 = i;
                data.skill2 = i;

            }
        }

        for (int i = 0; i < character.Dodge.Length; i++)
        {
            if (character.Dodge[i] == characterData.dodgeSkill.dodge)
            {
                data.dodge = i;
            }
        }

        for (int i = 0; i < character.Ultimate.Length; i++)
        {
            if (character.Ultimate[i] == characterData.ultimateSkill.ultimate)
            {
                data.ultimate = i;
            }
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/CharacterSaveFile/" + character.name +".json", json);
    }

    public void LoadCharacterData(PlayableCharacterData characterData,Character character)
    {
        if (File.Exists(Application.dataPath + "/CharacterSaveFile/" + character.name + ".json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/CharacterSaveFile/" + character.name + ".json");
            LevelAndStats data = new();
            data = JsonUtility.FromJson<LevelAndStats>(json);
            for (int i = 0; i < data.statID.Count; i++)
            {
                characterDictionary[character].stats[i].statIdentifier = DictionaryStorage.TraitDictionary[characterDictionary[character].character.stats[i].statIdentifier.key];
                
                //characterDictionary[character].stats[i].statValue = data.currentStatValue[i];
                characterDictionary[character].stats[i].MinMaxValue = data.stats[i].MinMaxValue;
                //testing
                if (characterDictionary[character].stats[i].followMax)
                {
                    characterDictionary[character].stats[i].statValue = characterDictionary[character].stats[i].MinMaxValue[1] * MathF.Pow(characterDictionary[character].stats[i].statScaling, characterDictionary[character].level.lv - 1);

                }
                else
                {
                    characterDictionary[character].stats[i].statValue = data.currentStatValue[i];
                }
                //testing ends here
                if (!characterDictionary[character].statDictionary.ContainsKey(characterDictionary[character].stats[i].statIdentifier))
                {
                    characterDictionary[character].statDictionary.Add(characterDictionary[character].stats[i].statIdentifier, characterDictionary[character].stats[i]);

                }
            }

            characterDictionary[character].level = data.level;
            characterData.stats = characterDictionary[character].stats;
            characterData.level = data.level;

            characterData.basicAttack = data.basicAttack;
            characterData.skill1 = data.skill1;
            characterData.skill2 = data.skill2;
            characterData.dodge = data.dodge;
            characterData.ultimate = data.ultimate;

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

    public void SaveGameData()
    {
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(Application.dataPath + "/StoryProgress.json", json);
    }

    public void LoadGameData()
    {
        if (File.Exists(Application.dataPath + "/StoryProgress.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/StoryProgress.json");
            gameData = JsonUtility.FromJson<GameStoryData>(json);
        }
        else
        {
            gameData.lastSavedPosition = new Vector3(-1.5f, 2f, 1f);
            gameData.currentStoryProgress = 0;
            SaveGameData();
        }
       
    }
}

[Serializable]
public class GameStoryData
{
    public int currentStoryProgress;
    public Vector3 lastSavedPosition;

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
    public List<float> currentStatValue = new();
    public List<Stat> stats = new();
    //public CurrentSkill skill;

    public int basicAttack;
    public int skill1;
    public int skill2;
    public int dodge;
    public int ultimate;
}

[Serializable]
public class CurrentSkill
{

    //store these in respective handlers
    public int basicAttack;
    public int skill1;
    public int skill2;
    public int dodge;
    public int ultimate;

}