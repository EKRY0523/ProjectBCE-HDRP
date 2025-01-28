using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class GameManager : EventHandler
{
    public InputActionReference action;
    public static GameManager instance;
    public DictionaryStorage storage;

    public Dictionary<Character, PlayableCharacterData> characterDictionary = new();
    public Dictionary<int, Character> characterIdentifier = new();

    public Dictionary<int, PlayableCharacterData> characterLoading = new();

    //public characters

    public List<PlayableCharacterData> characters; // use this mainly
    public List<PlayableCharacterData> UnlockedCharacters = new(); //partysetup needs this
    public SaveProgress progress;
    public PartyHandler party;

    public PlayableCharacterData FirstCharacter;
    public List<PlayableCharacterData> charactersInParty = new();
    public List<PlayableCharacterData> deadCharacters = new();

    //public static GameStoryData gameData;
    public int storyProgress;
    public Vector3 savedPosition;
    public GameObject player;

    public AudioMixer audioMixer;

    public VolumeBind volData;
    public override void Awake()
    {
        instance = this;
        if(SceneManager.GetActiveScene().buildIndex!=0)
        {

            LoadInCharacterDictionary();

            LoadGame();
        }

        LoadVolume();
        base.Awake();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        LoadVolume();
    }
    public void LoadInCharacterDictionary()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if(!characterLoading.ContainsKey(characters[i].character.ID))
            {
                characterLoading.Add(characters[i].character.ID, characters[i]);
                characterLoading[characters[i].character.ID].InitializeCharacter();
            }
        }
    }
    public void SaveGame()
    {
        LoadInCharacterDictionary();
        Debug.Log("save scene in" + SceneManager.GetActiveScene().buildIndex);
        SaveProgress currentProgress = new SaveProgress();
        if (!File.Exists(Application.persistentDataPath + "/SaveFile.json"))
        {
            FirstTimeSave();
        }
        else
        {
            currentProgress.storyProgress = storyProgress;
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                currentProgress.savedPosition = player.transform.position;
            }
            //else
            //{
            //    currentProgress.savedPosition = savedPosition;
            //}

            for (int i = 0; i < characters.Count; i++)
            {
                CharacterProgressData charData = new();
                charData.characterID = characterLoading[characters[i].character.ID].character.ID;
                charData.unlocked = characterLoading[characters[i].character.ID].unlocked;
                charData.lv = characterLoading[characters[i].character.ID].lv;
                charData.currentEXP = characterLoading[characters[i].character.ID].currentEXP;
                charData.ExpNeeded = characterLoading[characters[i].character.ID].ExpNeeded;
                charData.basicAttack = characterLoading[characters[i].character.ID].basicAttack;
                charData.skill1 = characterLoading[characters[i].character.ID].skill1;
                charData.skill2 = characterLoading[characters[i].character.ID].skill2;
                charData.dodge = characterLoading[characters[i].character.ID].dodge;
                charData.ultimate = characterLoading[characters[i].character.ID].ultimate;


                for (int j = 0; j < characters[i].character.stats.Length; j++)
                {
                    charData.StatID.Add(characterLoading[characters[i].character.ID].character.stats[j].statIdentifier.key);
                    charData.stats.Add(characterLoading[characters[i].character.ID].stats[j]);
                    charData.currentStatValue.Add(characterLoading[characters[i].character.ID].stats[j].statValue);
                }

                currentProgress.characterData.Add(charData);
            }



            for (int i = 0; i < currentProgress.characterData.Count; i++)
            {
                if (currentProgress.characterData[i].unlocked)
                {
                    currentProgress.unlockedCharacterList.Add(currentProgress.characterData[i].characterID);
                    //currentProgress.currentPartySetup.Add(currentProgress.characterData[i].characterID);
                    //can add to this by having things like another script containing reference to the char ID, then unlock it, and directly save
                }
            }

            for (int i = 0; i < charactersInParty.Count; i++)
            {
                currentProgress.currentPartySetup.Add(charactersInParty[i].character.ID);
            }
            for (int i = 0; i < deadCharacters.Count; i++)
            {
                currentProgress.deadCharacters.Add(deadCharacters[i].character.ID);
            }
            string json = JsonUtility.ToJson(currentProgress, true);
            File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
        }
           
    }

    public void FirstTimeSave()
    {
        SaveProgress currentProgress = new SaveProgress();
        //GameStoryData storyData= new();
        currentProgress.storyProgress = 0;
        savedPosition = new Vector3(-1.5f, 2.5f, 0f);
        currentProgress.savedPosition = new Vector3(-1.5f, 2.5f, 0f);
        //currentProgress.gameData.currentStoryProgress = 0;
        //currentProgress.gameData.lastSavedPosition; 
        for (int i = 0; i < characters.Count; i++)
        {
            CharacterProgressData charData = new();
            charData.characterID = characters[i].character.ID;
            charData.unlocked = characters[i].unlocked;
            charData.lv = 1;
            charData.currentEXP = 0;
            charData.ExpNeeded = 100;
            charData.basicAttack = 0;
            charData.skill1 = 0;
            charData.skill2 = 1;
            charData.dodge = 0;
            charData.ultimate = 0;


            for (int j = 0; j < characters[i].character.stats.Length; j++)
            {
                charData.StatID.Add(characters[i].character.stats[j].statIdentifier.key);
                charData.stats.Add(characters[i].character.stats[j]);
                charData.currentStatValue.Add(characters[i].character.stats[j].MinMaxValue[1]);
            }

            currentProgress.characterData.Add(charData);
        }

        for (int i = 0; i < currentProgress.characterData.Count; i++)
        {
            if(currentProgress.characterData[i].unlocked)
            {
                currentProgress.unlockedCharacterList.Add(currentProgress.characterData[i].characterID);
                currentProgress.currentPartySetup.Add(currentProgress.characterData[i].characterID);

                //charactersInParty.Add(characterLoading[currentProgress.characterData[i].characterID]);
            }
        }


        string json = JsonUtility.ToJson(currentProgress, true);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
        LoadGame();
    }

    public void LoadGame()
    {
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
        Debug.Log("load scene in" + SceneManager.GetActiveScene().buildIndex);
        LoadInCharacterDictionary();
        if (File.Exists(Application.persistentDataPath + "/SaveFile.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/SaveFile.json");
            SaveProgress currentProgress = JsonUtility.FromJson<SaveProgress>(json);
            storyProgress = currentProgress.storyProgress;
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                savedPosition = currentProgress.savedPosition;
                if(player!=null)
                {
                    if (savedPosition == new Vector3(0, 0, 0))
                    {
                        savedPosition = new Vector3(-1.5f, 2.5f, 0f);
                    }
                    player.transform.position = savedPosition;
                }
            }
            //CHAR DATA
            for (int i = 0; i < currentProgress.characterData.Count; i++)
            {
                characterLoading[currentProgress.characterData[i].characterID].lv = currentProgress.characterData[i].lv;

                characterLoading[currentProgress.characterData[i].characterID].currentEXP = currentProgress.characterData[i].currentEXP;
                characterLoading[currentProgress.characterData[i].characterID].ExpNeeded = currentProgress.characterData[i].ExpNeeded;
                characterLoading[currentProgress.characterData[i].characterID].unlocked = currentProgress.characterData[i].unlocked;
                characterLoading[currentProgress.characterData[i].characterID].basicAttack = currentProgress.characterData[i].basicAttack;
                characterLoading[currentProgress.characterData[i].characterID].skill1 = currentProgress.characterData[i].skill1;
                characterLoading[currentProgress.characterData[i].characterID].skill2 = currentProgress.characterData[i].skill2;
                characterLoading[currentProgress.characterData[i].characterID].dodge = currentProgress.characterData[i].dodge;
                characterLoading[currentProgress.characterData[i].characterID].ultimate = currentProgress.characterData[i].ultimate;

                for (int j = 0; j < characterLoading[currentProgress.characterData[i].characterID].character.stats.Length; j++)
                {
                    if (currentProgress.characterData[i].StatID[j] ==  DictionaryStorage.TraitDictionary[characterLoading[currentProgress.characterData[i].characterID].stats[j].statIdentifier.key].key) //get the ID
                    {
        
                        characterLoading[currentProgress.characterData[i].characterID].stats[j].statIdentifier = DictionaryStorage.TraitDictionary[currentProgress.characterData[i].StatID[j]];
                        characterLoading[currentProgress.characterData[i].characterID].stats[j].statAction = characterLoading[currentProgress.characterData[i].characterID].character.stats[j].statAction;
                        characterLoading[currentProgress.characterData[i].characterID].stats[j].statValue = currentProgress.characterData[i].currentStatValue[j];
                        characterLoading[currentProgress.characterData[i].characterID].stats[j].MinMaxValue[1] = characterLoading[currentProgress.characterData[i].characterID].character.stats[j].MinMaxValue[1] * currentProgress.characterData[i].stats[j].statScaling * currentProgress.characterData[i].lv;
                        if (characterLoading[currentProgress.characterData[i].characterID].stats[j].followMax)
                        {
                            characterLoading[currentProgress.characterData[i].characterID].stats[j].statValue = characterLoading[currentProgress.characterData[i].characterID].character.stats[j].MinMaxValue[1] * currentProgress.characterData[i].stats[j].statScaling * currentProgress.characterData[i].lv;
                        }

                    }
                }
            }

            for (int i = 0; i < currentProgress.unlockedCharacterList.Count; i++)
            {
                if(!UnlockedCharacters.Contains(characterLoading[currentProgress.unlockedCharacterList[i]]))
                {
                UnlockedCharacters.Add(characterLoading[currentProgress.unlockedCharacterList[i]]);

                }
            }

            //PARTY DATA
            for (int i = 0; i < currentProgress.currentPartySetup.Count; i++)
            {

                charactersInParty.Add(characterLoading[currentProgress.currentPartySetup[i]]);
            }

            //DEAD CCOUNT
            for (int i = 0; i < currentProgress.deadCharacters.Count; i++)
            {
                deadCharacters.Add(characterLoading[currentProgress.deadCharacters[i]]);
            }
        }
        else
        {
            SaveGame();
        }
       

    }

    public void LoadVolume()
    {
        volData.volume.Clear();
        volData.enabled.Clear();
        if (File.Exists(Application.persistentDataPath + "/AudioSettings.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/AudioSettings.json");
            VolumeBind volbind = JsonUtility.FromJson<VolumeBind>(json);

            for (int i = 0; i < volbind.volume.Count; i++)
            {
                volData.enabled.Add(volbind.enabled[i]);
                volData.volume.Add(volbind.volume[i]);
                float finalVol = Mathf.Log10(volbind.volume[i]) * 20;
                if(i == 0)
                {
                    if(volData.enabled[i])
                    {
                        audioMixer.SetFloat("Master", finalVol);
                    }
                    else
                    {
                        audioMixer.SetFloat("Master", -90f);
                    }
                }
                else if(i == 1)
                {
                    if (volData.enabled[i])
                    {
                        audioMixer.SetFloat("BGM", finalVol);
                    }
                    else
                    {

                        audioMixer.SetFloat("BGM", -90f);
                    }
                }
                else
                {
                    if (volData.enabled[i])
                    {
                        audioMixer.SetFloat("SFX", finalVol);
                    }
                    else
                    {
                        audioMixer.SetFloat("SFX", -90f);
                    }
                    
                }
            }

            
        }
        else
        {
            VolumeBind volbind = new();
            for (int i = 0; i < 3; i++)
            {
                if(volData.volume.Count< 3)
                {
                    volData.volume.Add(0.5f);
                    volData.enabled.Add(true);
                }
            }
            volbind.volume = volData.volume;
            volbind.enabled = volData.enabled;
            string json = JsonUtility.ToJson(volbind, true);
            File.WriteAllText(Application.persistentDataPath + "/AudioSettings.json", json);
            LoadVolume();
        }
    }

    public void SaveVolumeSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/AudioSettings.json"))
        {
            VolumeBind volbind = new();
            for (int i = 0; i < volData.volume.Count; i++)
            {
                volbind.volume.Add(volData.volume[i]);
                volbind.enabled.Add(volData.enabled[i]);
            }
            string json = JsonUtility.ToJson(volbind, true);
            File.WriteAllText(Application.persistentDataPath + "/AudioSettings.json", json);
        }
    }

    private void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SaveGame();
            SaveVolumeSettings();
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
    public int storyProgress;
    public Vector3 savedPosition;
    public List<int> unlockedCharacterList = new(); // get minori as first, this and setup uses character ID
    public List<int> currentPartySetup = new();
    public List<int> deadCharacters = new();
    public GameStoryData gameData;
    public List<CharacterProgressData> characterData = new();
}

[Serializable]
public class CharacterProgressData
{
    public bool unlocked;
    public int lv;
    public float currentEXP;
    public float ExpNeeded;
    public int characterID;
    public List<int> StatID = new();
    public List<float> currentStatValue = new();
    public List<Stat> stats = new();
    public int basicAttack;
    public int skill1;
    public int skill2;
    public int dodge;
    public int ultimate;
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

[Serializable]
public class VolumeBind
{ //0 is bgm, 1 is sfx
    public List<bool> enabled = new();
    public List<float> volume = new();

}