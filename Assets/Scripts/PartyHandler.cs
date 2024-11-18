using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class PartyHandler : EventHandler
{
    [SerializeField]protected PlayerInput playerInput;
    public List<PlayableCharacterData> characterList = new();
    public PlayableCharacterData activeCharacter;
    public int deadCount;

    //public Action[] test;

    public CharacterStatusHandler[] statusHandlers;
    public bool CanSwitch;
    public float SwitchCD;
    public float timeSinceLastSwitch;
    public override void Awake()
    {
        base.Awake();
        Initialize();
    }

    private void Start()
    {
        //Initialize();
        activeCharacter = characterList[0];
        MBEvent?.Invoke(null, activeCharacter);
        if (SceneManager.GetActiveScene().buildIndex == 1) //teleport
        {
            transform.position = GameManager.instance.gameData.lastSavedPosition;
        }
    }
    
    public void OnCharacterChange(int index)
    {

        if(index < characterList.Count)
        {
            if(CanSwitch)
            {
                timeSinceLastSwitch = Time.time;
                CanSwitch = false;
                MBEvent?.Invoke(null, activeCharacter);
                activeCharacter.gameObject.SetActive(false);
                activeCharacter = characterList[index];
                activeCharacter.gameObject.SetActive(true);

                SOEvent[0].globalEvent?.Invoke(activeCharacter);
            }
        }
        
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);

    }

    public void LateStart()
    {

    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        playerInput.SwitchOne -= OnCharacterChange;
        playerInput.SwitchTwo -= OnCharacterChange;
        playerInput.SwitchThree -= OnCharacterChange;
    }
    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
        if (data is List<PlayableCharacterData>)
        {
            for (int i = 0; i < statusHandlers.Length; i++)
            {
                statusHandlers[i].gameObject.SetActive(false);
            }
            List<PlayableCharacterData> tempData = (List<PlayableCharacterData>)data;

            for(int i = 0; i < characterList.Count; i++)
            {
                Destroy(characterList[i].gameObject);
            }

            characterList.Clear();
            for (int i = 0; i < tempData.Count; i++)
            {
                if (tempData[i] != null)
                {
                    characterList.Add(Instantiate(tempData[i], transform));
                    statusHandlers[i].gameObject.SetActive(true);
                    characterList[i].gameObject.SetActive(false);

                }
            }
            activeCharacter = characterList[0];
            activeCharacter.gameObject.SetActive(true);
            MBEvent?.Invoke(null, activeCharacter);
            SOEvent[0].globalEvent?.Invoke(activeCharacter);
            Setup();
            //StartCoroutine(ResetShit());
            GameManager.instance.SaveData();
        }
    }

    public void Initialize()
    {
        CanSwitch = true;
        if (GameManager.instance != null)
        {
            if (GameManager.instance.CheckExistData())
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

        playerInput.SwitchOne += OnCharacterChange;
        playerInput.SwitchTwo += OnCharacterChange;
        playerInput.SwitchThree += OnCharacterChange;

        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].gameObject.SetActive(false);
            GameManager.instance.LoadCharacterData(characterList[i], characterList[i].character);
        }

        activeCharacter = characterList[0];
        activeCharacter.gameObject.SetActive(true);
        MBEvent?.Invoke(null, activeCharacter);

        SOEvent[0].globalEvent?.Invoke(activeCharacter);
    }
    private void Update()
    {
        if(Time.time > timeSinceLastSwitch + SwitchCD)
        {
            CanSwitch = true;
        }
    }

    public void Setup()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].gameObject?.SetActive(true);
            statusHandlers[i].OnGlobalEventInvoke(characterList[i]);

            characterList[i].gameObject?.SetActive(false);
        }

        activeCharacter.gameObject.SetActive(true);
    }
    IEnumerator ResetShit()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].gameObject?.SetActive(true);
            statusHandlers[i].OnGlobalEventInvoke(characterList[i]);
        }

        yield return new WaitForSeconds(5f);

        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].gameObject?.SetActive(false);
        }
        activeCharacter.gameObject.SetActive(true);
    }

    IEnumerator openShit(GameObject data)
    {
        yield return new WaitForSeconds(2f);
        data.SetActive(true);
    }
}
