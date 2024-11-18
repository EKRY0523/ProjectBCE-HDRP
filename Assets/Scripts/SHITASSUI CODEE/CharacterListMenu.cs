using UnityEngine;
using UnityEngine.UI;

public class CharacterListMenu : EventHandler
{
    public Character[] character;
    public Button[] characterButton;
    public GameObject[] thingsToInitialize;
    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < characterButton.Length; i++)
        {
            int num = i;
            characterButton[i].onClick.AddListener(()=>DisplayCharacter(character[num]));
        }
       
    }

    private void Start()
    {
        SOEvent[0].globalEvent?.Invoke(null);
        DisplayCharacter(character[0]);

    }
    private void OnEnable()
    {
        SOEvent[0].globalEvent?.Invoke(null);
        DisplayCharacter(character[0]);
        InitializeData();
    }

    public void InitializeData()
    {
        for (int i = 0; i < thingsToInitialize.Length; i++)
        {
            thingsToInitialize[i].SetActive(true);
        }
        SOEvent[0].globalEvent?.Invoke(null);
        DisplayCharacter(character[0]);
        for (int i = 0; i < thingsToInitialize.Length; i++)
        {
            thingsToInitialize[i].SetActive(false);
        }

    }

    public void DisplayCharacter(Character character)
    {
        MBEvent?.Invoke(null, character);
    }

}
