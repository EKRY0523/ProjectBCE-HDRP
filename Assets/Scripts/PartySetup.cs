using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class PartySetup : EventHandler
{
    
    public List<PlayableCharacterData> charactersList;

    //[SerializeField] public List<PlayableCharacterData> charactersInParty = new();

    //public List<PartyBackgroundHandler> bgList = new();

    //public PartyBackgroundHandler characterBGPrefab;

    public PartyHandler partyHandler; //dont use this, use json
    public Button[] characterSlot;
    public RawImage[] charImage;
    public CharacterSelection charSelectionMenu;
    public Button BackButton, ConfirmButton;
    public GameObject[] objectsToTurnOff;


    //public List<PlayableCharacterData> charactersInParty = new();
    public List<PlayableCharacterData> charactersInParty;

    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < characterSlot.Length; i++)
        {
            int num = i;
            characterSlot[i].onClick.AddListener(() => SelectCharacter(num));
        }

        BackButton.onClick.AddListener(Back);
        ConfirmButton.onClick.AddListener(Confirm);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        
    }
    private void Start()
    {
        charactersInParty = GameManager.instance.charactersInParty;

        DisplayCharacters();
    }

    private void OnEnable()
    {
        DisplayCharacters();

    }

    public void DisplayCharacters()
    {
        //turn off first
        for (int i = 0; i < charImage.Length; i++)
        {
            charImage[i].gameObject.SetActive(false);
        }

        //update and turn on
        for (int i = 0; i < charactersInParty.Count; i++)
        {
            charImage[i].texture = charactersInParty[i].character.poseImage;
            charImage[i].gameObject.SetActive(true);
        }
    }

    public void SelectCharacter(int index)
    {
        charSelectionMenu.index = index;
        charSelectionMenu.gameObject.SetActive(true);
    }

    public void Back()
    {
        for (int i = 0; i < objectsToTurnOff.Length; i++)
        {
            objectsToTurnOff[i].SetActive(false);
        }
    }
    public void Confirm()
    {
        //SOEvent[0]?.globalEvent?.Invoke(charactersToSwitchIn);
        for (int i = 0; i < objectsToTurnOff.Length; i++)
        {
            objectsToTurnOff[i].SetActive(false);
        }
        for (int i = 0; i < GameManager.instance.charactersInParty.Count; i++)
        {
            GameManager.instance.characterLoading[charactersInParty[i].character.ID].InitializeCharacter();
            GameManager.instance.characterLoading[charactersInParty[i].character.ID].GetComponent<EffectHandler>().ReloadPassive();
        }
        SOEvent[0].globalEvent?.Invoke(null);

        //charactersToSwitchIn.Clear();
    }
    //public override void Awake()
    //{
    //    base.Awake();


    //    for (int i = 0; i < characterSlot.Length; i++)
    //    {
    //        int num = i;
    //        characterSlot[i].onClick.AddListener(()=>EnableCharSelection(num));
    //    }

    //    BackButton.onClick.AddListener(Back);
    //    ConfirmButton.onClick.AddListener(Confirm);

    //}
    //private void OnEnable()
    //{
    //    if (GameManager.instance != null)
    //    {
    //        GameManager.instance.LoadData();
    //        while (charactersToSwitchIn.Count != 3)
    //        {
    //            charactersToSwitchIn.Add(null);
    //        }
    //        charactersList = GameManager.instance.UnlockedCharacters;

    //    }
    //    ReloadList();
    //}


    //private void OnDisable()
    //{
    //    for (int i = 0; i < bgList.Count; i++)
    //    {
    //        Destroy(bgList[i].gameObject);
    //    }
    //    bgList.Clear();
    //}


    //public void ReloadList()
    //{
    //    for (int i = 0; i < bgList.Count; i++)
    //    {
    //        Destroy(bgList[i].gameObject);
    //    }
    //    bgList.Clear();

    //    for (int i = 0; i < charactersToSwitchIn.Count; i++)
    //    {
    //        if(charactersToSwitchIn[i] == null)
    //        {
    //            charactersToSwitchIn.RemoveAt(i);

    //        }
    //    }
    //    for (int i = 0; i < charactersToSwitchIn.Count; i++)
    //    {
    //        if (charactersToSwitchIn[i] != null)
    //        {
    //            bgList.Add(Instantiate(characterBGPrefab, characterSlot[i].transform));
    //            bgList[i].mat.material = charactersToSwitchIn[i].character.material;
    //            bgList[i].image.texture = charactersToSwitchIn[i].character.poseImage;
    //        }

    //    }
    //    while (charactersToSwitchIn.Count != 3)
    //    {
    //        charactersToSwitchIn.Add(null);
    //    }
    //}



    //public void EnableCharSelection(int index)
    //{
    //    charSelectionMenu.index = index;
    //    charSelectionMenu.gameObject.SetActive(true);
    //}

    //public override void OnInvoke(Trait ID, object data)
    //{
    //    base.OnInvoke(ID, data);
    //    if(data is List<PlayableCharacterData>)
    //    {

    //    }
    //}

    //public override void OnGlobalEventInvoke(object data)
    //{
    //    base.OnGlobalEventInvoke(data);
    //    if (data is List<PlayableCharacterData>)
    //    {
    //        charactersToSwitchIn = (List<PlayableCharacterData>)data;
    //        ReloadList();
    //    }
    //}
}
