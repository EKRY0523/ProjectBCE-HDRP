using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
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
    PlayableCharacterData oldCharacter;
    public override void Awake()
    {
        
    }

    private void OnEnable()
    {
        if (GameManager.instance != null)
        {
            //change to unlocked characters
            for (int i = 0; i < GameManager.instance.UnlockedCharacters.Count; i++)
            {
                int num = i;

                characterButtons.Add(Instantiate(buttonPrefab, characterGrid.transform));
                characterButtons[i].image.sprite = GameManager.instance.characters[i].character.iconimage;
                characterButtons[i].onClick.AddListener(() => ShowCharacter(GameManager.instance.characters[num].character.poseImage, GameManager.instance.characters[num]));
            }
        }

        oldCharacter = partySetup.charactersToSwitchIn[index];
        confirmButton.onClick.AddListener(ChangeCharacter);
        BackButton.onClick.AddListener(Back);
        RemoveButton.onClick.AddListener(RemoveCharacterFromParty);
    }

    private void OnDisable()
    {
        for (int i = 0; i < characterButtons.Count; i++)
        {
            int num = i;

            Destroy(characterButtons[i].gameObject);
        }
        characterButtons.Clear();
        confirmButton.onClick.RemoveAllListeners();
        BackButton.onClick.RemoveAllListeners();
        RemoveButton.onClick.RemoveAllListeners();
    }
    public void ShowCharacter(RenderTexture partyPose,PlayableCharacterData data)
    {
        charPanel.SetActive(true);
        charImage.texture = partyPose;
        charData = data.character;
        characterData = data;
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }

    public void ChangeCharacter()
    {
        for (int i = 0; i < partySetup.charactersToSwitchIn.Count; i++)
        {
            if (partySetup.charactersToSwitchIn[i] != null)
            {
                if (partySetup.charactersToSwitchIn[i].character == charData)
                {
                    //switch position
                    partySetup.charactersToSwitchIn[i] = oldCharacter;
                    partySetup.charactersToSwitchIn[index] = characterData;

                    Debug.Log("Met in switching two ");
                    partySetup.ReloadList();
                    charPanel.SetActive(false);
                    return;
                }
                else
                {
                    partySetup.charactersToSwitchIn[index] = characterData;
                    Debug.Log("Met in just switchn");
                }

            }
            
        }
        partySetup.ReloadList();
        charPanel.SetActive(false);
    }

    public void RemoveCharacterFromParty()
    {
        currentNonEmpty = 0;

        for (int i = 0; i < partySetup.charactersToSwitchIn.Count; i++)
        {
            if(partySetup.charactersToSwitchIn[i]!= null)
            {
                currentNonEmpty += 1;
            }
        }

        if(currentNonEmpty != 1)
        {
            partySetup.charactersToSwitchIn.RemoveAt(index);
            partySetup.charactersToSwitchIn.Add(null);
            partySetup.ReloadList();
        }

        else
        {
            //show UI here
            Debug.Log("need at least one character");
        }
        
    }
}
