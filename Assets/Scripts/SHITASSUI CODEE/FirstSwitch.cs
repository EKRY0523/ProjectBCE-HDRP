using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class FirstSwitch : EventHandler
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

    public int secondary;
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
        skillDescription.text = character.Skills[currentSkillIndex].skillDescription;
        skillName.text = character.Skills[currentSkillIndex].skillName;
        skillCost.text = character.Skills[currentSkillIndex].cost.stat.name + ": " + character.Skills[currentSkillIndex].cost.cost;
        skillCooldown.text = "CD: " + character.Skills[currentSkillIndex].cooldown[0];

        for (int i = 0; i < skillOptionIcon.Length; i++)
        {
            skillOptionIcon[i].sprite = character.Skills[i].skillIcon;
        }
    }

    private void OnEnable()
    {
        currentSkillIndex = GameManager.instance.characterLoading[character.ID].skill1;

        skillDescription.text = character.Skills[currentSkillIndex].skillDescription;
        skillName.text = character.Skills[currentSkillIndex].skillName;
        skillCost.text = character.Skills[currentSkillIndex].cost.stat.name + ": " + character.Skills[currentSkillIndex].cost.cost;
        skillCooldown.text = "CD: " + character.Skills[currentSkillIndex].cooldown[0];

        for (int i = 0; i < skillOptionIcon.Length; i++)
        {
            skillOptionIcon[i].sprite = character.Skills[i].skillIcon;
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
        GameManager.instance.characterLoading[character.ID].skill1 = index;
        GameManager.instance.characterLoading[character.ID].firstSkill.OnChangeSkill(character.Skills[index]);

        skillDescription.text = character.Skills[index].skillDescription;
        skillName.text = character.Skills[index].skillName;
        skillCost.text = character.Skills[index].cost.stat.name + ": " + character.Skills[index].cost.cost;
        skillCooldown.text = "CD: " + character.Skills[currentSkillIndex].cooldown[0];

        currentSkllIcon.sprite = character.Skills[index].skillIcon;


        gameObject.SetActive(false);

        successText.text = "Sucessfully changed " + "<color=#FF8F85>" + character.Skills[currentSkillIndex].skillName + "</color>"
                            + " To " + "<color=#87FF84>" + character.Skills[index].skillName + "</color>";

        switchSkillPanel.SetActive(false);
        successMenu.SetActive(true);

    }

    public void ShowSkill(int index)
    {
        switchSkillPanel.SetActive(true);
        newSkillDescription.text = character.Skills[index].skillDescription;
        newSkillName.text = character.Skills[index].skillName;

        if (index == currentSkillIndex || index == GameManager.instance.characterLoading[character.ID].skill2)
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
            currentSkillIndex = GameManager.instance.characterLoading[character.ID].skill1;
            skillDescription.text = character.Skills[currentSkillIndex].skillDescription;
            skillName.text = character.Skills[currentSkillIndex].skillName;
            for (int i = 0; i < skillOptionIcon.Length; i++)
            {
                skillOptionIcon[i].sprite = character.Skills[i].skillIcon;
            }
            this.gameObject.SetActive(false);
        }
    }
}
