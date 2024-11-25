using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class DodgeSwitch : EventHandler
{
    public Character character;
    public Button[] skillOption;
    public Image[] skillOptionIcon;
    public int currentSkillIndex;

    [Header("Base")]
    public TextMeshProUGUI skillDescription;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillCost;
    public TextMeshProUGUI skillCooldown;

    public Button SwitchButton;
    public GameObject switchSkillOption;
    public Image currentSkllIcon;

    [Header("Switch")]
    public GameObject switchSkillPanel;
    public TextMeshProUGUI newSkillDescription;
    public TextMeshProUGUI newSkillName;
    public TextMeshProUGUI newSkillCost;
    public TextMeshProUGUI newSkillCooldown;

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
            skillOption[i].onClick.AddListener(() => ShowSkill(num));
        }
        SwitchButton.onClick.AddListener(TurnOnSwitch);
        cancelButton.onClick.AddListener(CancelChange);
    }

    private void Start()
    {
        skillDescription.text = character.Dodge[currentSkillIndex].skillDescription;
        skillName.text = character.Dodge[currentSkillIndex].skillName;
        skillCost.text = character.Dodge[currentSkillIndex].cost.stat.name + ": " + character.Dodge[currentSkillIndex].cost.cost;
        skillCooldown.text = "CD: " + character.Dodge[currentSkillIndex].cooldown[0];

        for (int i = 0; i < skillOptionIcon.Length; i++)
        {
            skillOptionIcon[i].sprite = character.Dodge[i].skillIcon;
        }
    }

    private void OnEnable()
    {
        currentSkillIndex = GameManager.instance.characterLoading[character.ID].dodge;

        skillDescription.text = character.Dodge[currentSkillIndex].skillDescription;
        skillName.text = character.Dodge[currentSkillIndex].skillName;
        skillCost.text = character.Dodge[currentSkillIndex].cost.stat.name + ": " + character.Dodge[currentSkillIndex].cost.cost;
        skillCooldown.text = "CD: " + character.Dodge[currentSkillIndex].cooldown[0];

        for (int i = 0; i < skillOptionIcon.Length; i++)
        {
            skillOptionIcon[i].sprite = character.Dodge[i].skillIcon;
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
        GameManager.instance.characterLoading[character.ID].dodge = index;
        GameManager.instance.characterLoading[character.ID].dodgeSkill.OnChangeSkill(character.Dodge[index]);

        skillDescription.text = character.Dodge[index].skillDescription;
        skillName.text = character.Dodge[index].skillName;
        skillCost.text = character.Dodge[index].cost.stat.name + ": " + character.Dodge[index].cost.cost;
        skillCooldown.text = "CD: " + character.Dodge[currentSkillIndex].cooldown[0];

        currentSkllIcon.sprite = character.Dodge[index].skillIcon;


        gameObject.SetActive(false);

        successText.text = "Sucessfully changed " + "<color=#FF8F85>" + character.Dodge[currentSkillIndex].skillName + "</color>"
                            + " To " + "<color=#87FF84>" + character.Dodge[index].skillName + "</color>";

        switchSkillPanel.SetActive(false);
        successMenu.SetActive(true);

    }

    public void ShowSkill(int index)
    {
        switchSkillPanel.SetActive(true);
        newSkillDescription.text = character.Dodge[index].skillDescription;
        newSkillName.text = character.Dodge[index].skillName;

        if (index == currentSkillIndex || index == GameManager.instance.characterLoading[character.ID].dodge)
        {
            confirmButton.interactable = false;
        }
        else
        {
            confirmButton.interactable = true;
        }

        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(() => ConfirmChange(index));
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if (data is Character)
        {
            character = (Character)data;
            currentSkillIndex = GameManager.instance.characterLoading[character.ID].dodge;
            skillDescription.text = character.Dodge[currentSkillIndex].skillDescription;
            skillName.text = character.Dodge[currentSkillIndex].skillName;
            for (int i = 0; i < skillOptionIcon.Length; i++)
            {
                skillOptionIcon[i].sprite = character.Dodge[i].skillIcon;
            }
            this.gameObject.SetActive(false);
        }
    }
}
