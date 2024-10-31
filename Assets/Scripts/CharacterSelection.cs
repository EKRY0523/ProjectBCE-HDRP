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
    public Button confirmButton, BackButton;
    public PartySetup partySetup;
    public Character charData;
    public PlayableCharacterData characterData;


    private void OnDisable()
    {
    }

    private void OnEnable()
    {
        
    }

    public override void Awake()
    {
        if(GameManager.instance!=null)
        {
            for (int i = 0; i < GameManager.instance.characters.Count; i++)
            {
                int num=i;

                characterButtons.Add(Instantiate(buttonPrefab,characterGrid.transform));
                characterButtons[i].image.sprite = GameManager.instance.characters[i].character.iconimage;
                characterButtons[i].onClick.AddListener(()=>ShowCharacter(GameManager.instance.characters[num].character.poseImage, GameManager.instance.characters[num]));
            }
        }

        confirmButton.onClick.AddListener(ChangeCharacter);
        BackButton.onClick.AddListener(Back);
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
        for (int i = 0; i < partySetup.charactersInParty.Count; i++)
        {
            if(partySetup.charactersInParty[i].character== charData)
            {
                Debug.Log("already in party");
                return;
            }
        }

        partySetup.charactersToSwitchIn[index] = characterData;
        if(index > partySetup.bgList.Count-1)
        {
            partySetup.bgList.Add(Instantiate(partySetup.characterBGPrefab, partySetup.characterSlot[index].transform));
            partySetup.bgList[index].mat.material = charData.material;
            partySetup.bgList[index].image.texture = charData.poseImage;
        }
        else
        {
            if (partySetup.bgList[index])
            {
                //Destroy(partySetup.bgList[index].gameObject);
                partySetup.bgList.RemoveAt(index);
                partySetup.bgList.Add(Instantiate(partySetup.characterBGPrefab, partySetup.characterSlot[index].transform));
                partySetup.bgList[index].mat.material = charData.material;
                partySetup.bgList[index].image.texture = charData.poseImage;
            }
            else
            {
                partySetup.bgList.Add(Instantiate(partySetup.characterBGPrefab, partySetup.characterSlot[index].transform));
                partySetup.bgList[index].mat.material = charData.material;
                partySetup.bgList[index].image.texture = charData.poseImage;
            }
        }

        charPanel.SetActive(false);
    }
}
