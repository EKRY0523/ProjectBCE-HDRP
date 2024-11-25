using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class BasicSwitch : EventHandler
{
    public Character character;
    public Button[] skillOption;
    public Image[] skillOptionIcon;    
    public int currentSkillIndex;

    [Header("Base")]
    public TextMeshProUGUI skillDescription;
    public TextMeshProUGUI skillName;
    public Button SwitchButton;
    public GameObject switchSkillOption;
    public Image currentSkllIcon;

    [Header("Switch")]
    public GameObject switchSkillPanel;
    public TextMeshProUGUI newSkillDescription;
    public TextMeshProUGUI newSkillName;
    public Button confirmButton;
    public Button cancelButton;

    [Header("Feedback")]
    public GameObject successMenu;
    public TextMeshProUGUI successText;
    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < skillOption.Length; i++)
        {
            int num = i;
            skillOption[i].onClick.AddListener(()=>ShowSkill(num));
        }
        SwitchButton.onClick.AddListener(TurnOnSwitch);
        cancelButton.onClick.AddListener(CancelChange);
    }

    private void Start()
    {
        skillDescription.text = character.BasicAttack[currentSkillIndex].skillDescription;
        skillName.text = character.BasicAttack[currentSkillIndex].skillName;
        for (int i = 0; i < skillOptionIcon.Length; i++)
        {
            skillOptionIcon[i].sprite = character.BasicAttack[i].skillIcon;
        }
    }

    private void OnEnable()
    {
        currentSkillIndex = GameManager.instance.characterLoading[character.ID].basicAttack;
        skillDescription.text = character.BasicAttack[currentSkillIndex].skillDescription;
        skillName.text = character.BasicAttack[currentSkillIndex].skillName;
        for (int i = 0; i < skillOptionIcon.Length; i++)
        {
            skillOptionIcon[i].sprite = character.BasicAttack[i].skillIcon;
        }
    }

    private void OnDisable()
    {
        switchSkillPanel.SetActive(false);
        switchSkillOption.SetActive(false);
    }

    private void TurnOnSwitch()
    {
        switchSkillOption.SetActive(true);
    }
    private void CancelChange()
    {
        switchSkillPanel.SetActive(false);
    }

    public void ConfirmChange(int index)
    {

        GameManager.instance.characterLoading[character.ID].basicAttack = index;
        GameManager.instance.characterLoading[character.ID].basic.OnChangeSkill(character.BasicAttack[index]);

        skillDescription.text = character.BasicAttack[index].skillDescription;
        skillName.text = character.BasicAttack[index].skillName;
        currentSkllIcon.sprite = character.BasicAttack[index].skillIcon;

        gameObject.SetActive(false);

        successText.text = "Sucessfully changed " + "<color=#FF8F85>" + character.BasicAttack[currentSkillIndex].skillName + "</color>"
                            + " To " + "<color=#87FF84>" + character.BasicAttack[index].skillName + "</color>";

        switchSkillPanel.SetActive(false);
        successMenu.SetActive(true);

    }

    public void ShowSkill(int index)
    {
        switchSkillPanel.SetActive(true);
        newSkillDescription.text = character.BasicAttack[index].skillDescription;
        newSkillName.text = character.BasicAttack[index].skillName;

        if(index == currentSkillIndex)
        {
            confirmButton.interactable = false;
        }
        else
        {
            confirmButton.interactable = true;
        }

        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(()=>ConfirmChange(index));
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Character)
        {
            character = (Character)data;
            skillDescription.text = character.BasicAttack[currentSkillIndex].skillDescription;
            skillName.text = character.BasicAttack[currentSkillIndex].skillName;
            for (int i = 0; i < skillOptionIcon.Length; i++)
            {
                skillOptionIcon[i].sprite = character.BasicAttack[i].skillIcon;
            }
            this.gameObject.SetActive(false);
        }
    }
}
