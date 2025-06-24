using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SkillSwitchHandler : EventHandler
{
    public PlayableCharacterData characterData;
    public Character character;

    public Button basicButton;
    public Button firstSkillButton;
    public Button secondSkillButton;
    public Button dodgeSkillButton;
    public Button ultimateSkillButton;
    public Button[] passiveButton;

    public Image basicIcon;
    public Image firstSkillIcon;
    public Image secondSkillIcon;
    public Image dodgeIcon;
    public Image ultimateIcon;
    public Image passiveIcon1;
    public Image passiveIcon2;

    public BasicSwitch basic;
    public FirstSwitch firstSkill;
    public SecondSwitch secondSkill;
    public DodgeSwitch dodgeSkill;
    public UltimateSwitch ultimateSkill;
    public ShowPassive showPassive;

    public Button closeButton;
    public override void Awake()
    {
        base.Awake();
        basicButton.onClick.AddListener(TurnOnBasic);
        firstSkillButton.onClick.AddListener(TurnOnFirstSwitch);
        secondSkillButton.onClick.AddListener(TurnOnSecondSwitch);
        dodgeSkillButton.onClick.AddListener(TurnOnDodge);
        ultimateSkillButton.onClick.AddListener(TurnOnUltimate);
        closeButton.onClick.AddListener(CloseMenu);
        for (int i = 0; i < passiveButton.Length; i++)
        {
            int num = i;
            passiveButton[num].onClick.AddListener(() => ShowPassiveData(num));
        }
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        basic.character = character;
        firstSkill.character = character;
        secondSkill.character = character;
        dodgeSkill.character = character;
        ultimateSkill.character = character;
        showPassive.character = character;
    }

    private void OnDisable()
    {CloseMenu();
    }
    public void TurnOnBasic()
    {
        basic.gameObject.SetActive(true);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        ultimateSkill.gameObject.SetActive(false);

        showPassive.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    public void TurnOnFirstSwitch()
    {
        firstSkill.gameObject.SetActive(true);
        basic.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        ultimateSkill.gameObject.SetActive(false);

        showPassive.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    public void TurnOnSecondSwitch()
    {
        secondSkill.gameObject.SetActive(true);
        firstSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        ultimateSkill.gameObject.SetActive(false);

        showPassive.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);

    }

    public void TurnOnDodge()
    {
        dodgeSkill.gameObject.SetActive(true);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);
        ultimateSkill.gameObject.SetActive(false);

        showPassive.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    public void TurnOnUltimate()
    {
        ultimateSkill.gameObject.SetActive(true);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);

        showPassive.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    public void ShowPassiveData(int index)
    {
        ultimateSkill.gameObject.SetActive(false);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);

        showPassive.passiveIndex = index; 
        showPassive.gameObject.SetActive(false);
        showPassive.gameObject.SetActive(true);
        
        closeButton.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        ultimateSkill.gameObject.SetActive(false);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);

        showPassive.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }
   

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Character)
        {
            character = (Character)data;
            characterData = GameManager.instance.characterLoading[character.ID];
            basicIcon.sprite = character.BasicAttack[characterData.basicAttack].skillIcon;
            basic.character = character;
            firstSkillIcon.sprite = character.Skills[characterData.skill1].skillIcon;
            firstSkill.character = character;
            secondSkillIcon.sprite = character.Skills[characterData.skill2].skillIcon;
            secondSkill.character = character;
            dodgeIcon.sprite = character.Dodge[characterData.dodge].skillIcon;
            dodgeSkill.character = character;
            ultimateIcon.sprite = character.Ultimate[characterData.ultimate].skillIcon;
            ultimateSkill.character = character;
            passiveIcon1.sprite = character.passive[0].Icon;
            showPassive.character = character;
            passiveIcon2.sprite = character.passive[1].Icon;
        }
    }

}
