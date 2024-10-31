using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class PartySetup : EventHandler
{
    
    public List<PlayableCharacterData> charactersList;

    [SerializeField] public List<PlayableCharacterData> charactersInParty = new();
    public PartyHandler handler;
    public Button[] characterSlot;
    public List<PartyBackgroundHandler> bgList = new();
    public CharacterSelection charSelectionMenu;
    public PartyBackgroundHandler characterBGPrefab;
    public Button BackButton, ConfirmButton;

    [SerializeField] public List<PlayableCharacterData> charactersToSwitchIn = new();

    public override void Awake()
    {
        base.Awake();
        

        for (int i = 0; i < characterSlot.Length; i++)
        {
            int num = i;
            characterSlot[i].onClick.AddListener(()=>EnableCharSelection(num));
        }

        BackButton.onClick.AddListener(Back);
        ConfirmButton.onClick.AddListener(Confirm);

    }

    private void OnEnable()
    {
        if (GameManager.instance != null)
        {
            charactersList = GameManager.instance.UnlockedCharacters;
        }
        for (int i = 0; i < handler.characterList.Count; i++)
        {
            charactersInParty.Add(GameManager.instance.characterDictionary[handler.characterList[i].character]);
        }

        for (int i = 0; i < charactersInParty.Count; i++)
        {
            charactersToSwitchIn[i] = charactersInParty[i];
            //charactersToSwitchIn[i] = GameManager.instance.characterDictionary[charactersInParty[i].character];
            bgList.Add(Instantiate(characterBGPrefab, characterSlot[i].transform));
            bgList[i].mat.material = charactersInParty[i].character.material;
            bgList[i].image.texture = charactersInParty[i].character.poseImage;
        }

        while(charactersToSwitchIn.Count != 3)
        {
            charactersToSwitchIn.Add(null);
        }
    }

    private void OnDisable()
    {
        charactersInParty.Clear();
        bgList.Clear();
    }

    public void Back()
    {
        this.gameObject.SetActive(false);
    }

    public void Confirm()
    {
        for (int i = 0; i < handler.characterList.Count; i++)
        {
            Destroy(handler.characterList[i].gameObject);
            handler.characterList.Remove(charactersInParty[i]);
        }

        MBEvent?.Invoke(null, charactersToSwitchIn);
        this.gameObject.SetActive(false);

        //charactersToSwitchIn.Clear();
    }

    public void EnableCharSelection(int index)
    {
        charSelectionMenu.index = index;
        charSelectionMenu.gameObject.SetActive(true);
    }

    public void RemoveCharacterFromList(PlayableCharacterData data)
    {
        
    }

    public void AddCharacterToList(PlayableCharacterData data)
    {

    }
    public void OnSetup(PlayableCharacterData data)
    {

    }
}
