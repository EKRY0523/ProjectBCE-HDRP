using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class CharacterSelection : EventHandler
{
    public int index;
    public Button buttonPrefab;
    public List<Button> characterButtons = new();
    public GameObject characterGrid,charPanel;
    public RawImage charImage;
    public Button confirmButton, BackButton,RemoveButton;
    public PartySetup partySetup;
    public Character charData;

    int currentNonEmpty;

    public PlayableCharacterData characterData;
    public int characterID;

    PlayableCharacterData oldCharacter;
    public int currentExistingIndex;

    public TextMeshProUGUI confirmText;
    public override void Awake()
    {
        base.Awake();
        BackButton.onClick.AddListener(Back);
        confirmButton.onClick.AddListener(ChangeCharacter);
        RemoveButton.onClick.AddListener(RemoveCharacterFromParty);
    }

    private void Start()
    {
        confirmText = confirmButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        partySetup.DisplayCharacters();
    }
    private void OnEnable()
    {
        if(oldCharacter!=null)
        {
            oldCharacter =null;
        }

        if (GameManager.instance != null)
        {
            for (int i = 0; i < characterButtons.Count; i++)
            {
                Destroy(characterButtons[i].gameObject);
            }
            characterButtons.Clear();
            //change to unlocked characters
            for (int i = 0; i < GameManager.instance.UnlockedCharacters.Count; i++)
            {
                int num = i;
                characterButtons.Add(Instantiate(buttonPrefab, characterGrid.transform));
                characterButtons[i].image.sprite = GameManager.instance.UnlockedCharacters[i].character.iconimage;
                characterButtons[i].onClick.AddListener(() => ShowCharacter(GameManager.instance.UnlockedCharacters[num].character.poseImage, GameManager.instance.UnlockedCharacters[num]));
            }

        }


        if(index< GameManager.instance.charactersInParty.Count)
        {

            oldCharacter = GameManager.instance.charactersInParty[index];

            RemoveButton.gameObject.SetActive(true);
        }
        if(oldCharacter==null)
        {

            RemoveButton.gameObject.SetActive(false);
            if(confirmText!=null)
            {

                confirmText.text = "Confirm";
            }
            confirmButton.interactable = true;
            
        }
    }

    public void ShowCharacter(RenderTexture partyPose, PlayableCharacterData data)
    {
        charPanel.SetActive(true);
        charImage.texture = partyPose;
        charData = data.character;
        characterData = data;
        characterID = data.character.ID;

        if(oldCharacter!=null)
        {
            if (oldCharacter.character.ID == characterID)
            {
                confirmText.text = "Already In Party";
                confirmButton.interactable = false;
            }
            else
            {
                confirmText.text = "Confirm";
                confirmButton.interactable = true;
            }
        }
        
    }

    public void ChangeCharacter()
    {
        if (CheckExist())
        {
            SwitchPosition();
        }
        else
        {
            if(GameManager.instance.charactersInParty.Count>index)
            {
                GameManager.instance.charactersInParty[index].gameObject.SetActive(false);
                GameManager.instance.charactersInParty[index].RemoveFromParty();
                GameManager.instance.charactersInParty[index] = GameManager.instance.characterLoading[characterID];
                Debug.Log("can work");
                
            }
            else
            {
                if(!GameManager.instance.charactersInParty.Contains(GameManager.instance.characterLoading[characterID]))
                {
                    GameManager.instance.charactersInParty.Add(GameManager.instance.characterLoading[characterID]);
                    Debug.Log("why");
                }
            }

            //if(GameManager.instance.charactersInParty.Count<=index)
            //{
            //    if ((!GameManager.instance.charactersInParty.Contains(GameManager.instance.characterLoading[characterID])))
            //    {
            //        if(GameManager.instance.charactersInParty.Count<index)
            //        {
            //            GameManager.instance.charactersInParty.Add(GameManager.instance.characterLoading[characterID]);
            //        }
            //        else if(GameManager.instance.charactersInParty[index]!=null)
            //        {
            //            GameManager.instance.charactersInParty[index].gameObject.SetActive(false);
            //            GameManager.instance.charactersInParty[index] = GameManager.instance.characterLoading[characterID];
            //        }
            //    }
            //}
            

        }
        charPanel.SetActive(false);
        gameObject.SetActive(false);

    }

    public bool CheckExist()
    {
        for (int i = 0; i < GameManager.instance.charactersInParty.Count; i++)
        {
            if (GameManager.instance.charactersInParty[i].character.ID == characterID)
            {
                currentExistingIndex = i;
                return true;
            }
        }

        return false;
    }

    public void SwitchPosition()
    {
        if(index < GameManager.instance.charactersInParty.Count)
        {
            GameManager.instance.charactersInParty[index] = GameManager.instance.characterLoading[characterID];
            GameManager.instance.charactersInParty[currentExistingIndex] = GameManager.instance.characterLoading[oldCharacter.character.ID];

        }
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }

    public void RemoveCharacterFromParty()
    {
        if(GameManager.instance.charactersInParty.Count == 1)
        {
            Debug.Log("cannot remove since only less than one char");
            //showui
        }
        else
        {
            Debug.Log("done" + GameManager.instance.charactersInParty[index]);
            GameManager.instance.charactersInParty[index].RemoveFromParty();
            GameManager.instance.charactersInParty[index].gameObject.SetActive(false);
            GameManager.instance.charactersInParty.RemoveAt(index);
            gameObject.SetActive(false);

        }
        

        
    }
    //private void OnEnable()
    //{
    //    if (GameManager.instance != null)
    //    {
    //        //change to unlocked characters
    //        for (int i = 0; i < GameManager.instance.UnlockedCharacters.Count; i++)
    //        {
    //            int num = i;

    //            characterButtons.Add(Instantiate(buttonPrefab, characterGrid.transform));
    //            characterButtons[i].image.sprite = GameManager.instance.characters[i].character.iconimage;
    //            characterButtons[i].onClick.AddListener(() => ShowCharacter(GameManager.instance.characters[num].character.poseImage, GameManager.instance.characters[num]));
    //        }
    //    }

    //    oldCharacter = partySetup.charactersToSwitchIn[index];
    //    confirmButton.onClick.AddListener(ChangeCharacter);
    //    BackButton.onClick.AddListener(Back);
    //    RemoveButton.onClick.AddListener(RemoveCharacterFromParty);
    //}

    //private void OnDisable()
    //{
    //    for (int i = 0; i < characterButtons.Count; i++)
    //    {
    //        int num = i;

    //        Destroy(characterButtons[i].gameObject);
    //    }
    //    characterButtons.Clear();
    //    confirmButton.onClick.RemoveAllListeners();
    //    BackButton.onClick.RemoveAllListeners();
    //    RemoveButton.onClick.RemoveAllListeners();
    //}




    //public void ChangeCharacter()
    //{
    //    for (int i = 0; i < partySetup.charactersToSwitchIn.Count; i++)
    //    {
    //        if (partySetup.charactersToSwitchIn[i] != null)
    //        {
    //            if (partySetup.charactersToSwitchIn[i].character == charData)
    //            {
    //                //switch position
    //                partySetup.charactersToSwitchIn[i] = oldCharacter;
    //                partySetup.charactersToSwitchIn[index] = characterData;

    //                Debug.Log("heres the bug");

    //                partySetup.ReloadList();
    //                charPanel.SetActive(false);
    //                return;
    //            }
    //            else
    //            {

    //                partySetup.charactersToSwitchIn[index] = characterData;
    //                Debug.Log("heres the bug 2");
    //                charPanel.SetActive(false);
    //            }

    //        }

    //    }
    //    partySetup.ReloadList();
    //    charPanel.SetActive(false);
    //}

    //public void RemoveCharacterFromParty()
    //{
    //    currentNonEmpty = 0;

    //    for (int i = 0; i < partySetup.charactersToSwitchIn.Count; i++)
    //    {
    //        if(partySetup.charactersToSwitchIn[i]!= null)
    //        {
    //            currentNonEmpty += 1;
    //        }
    //    }

    //    if(currentNonEmpty != 1)
    //    {
    //        partySetup.charactersToSwitchIn.RemoveAt(index);
    //        partySetup.charactersToSwitchIn.Add(null);
    //        partySetup.ReloadList();
    //    }

    //    else
    //    {
    //        //show UI here
    //        Debug.Log("need at least one character");
    //    }

    //}
}
