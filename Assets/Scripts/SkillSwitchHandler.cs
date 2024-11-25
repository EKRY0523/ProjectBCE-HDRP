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

    public Image basicIcon;
    public Image firstSkillIcon;
    public Image secondSkillIcon;
    public Image dodgeIcon;
    public Image ultimateIcon;

    public BasicSwitch basic;
    public FirstSwitch firstSkill;
    public SecondSwitch secondSkill;
    public DodgeSwitch dodgeSkill;
    public UltimateSwitch ultimateSkill;

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
    }
    public void TurnOnBasic()
    {
        basic.gameObject.SetActive(true);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        ultimateSkill.gameObject.SetActive(false);

        closeButton.gameObject.SetActive(true);
    }

    public void TurnOnFirstSwitch()
    {
        firstSkill.gameObject.SetActive(true);
        basic.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        ultimateSkill.gameObject.SetActive(false);

        closeButton.gameObject.SetActive(true);
    }

    public void TurnOnSecondSwitch()
    {
        secondSkill.gameObject.SetActive(true);
        firstSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        ultimateSkill.gameObject.SetActive(false);

        closeButton.gameObject.SetActive(true);

    }

    public void TurnOnDodge()
    {
        dodgeSkill.gameObject.SetActive(true);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);
        ultimateSkill.gameObject.SetActive(false);

        closeButton.gameObject.SetActive(true);
    }

    public void TurnOnUltimate()
    {
        ultimateSkill.gameObject.SetActive(true);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);

        closeButton.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        ultimateSkill.gameObject.SetActive(false);
        firstSkill.gameObject.SetActive(false);
        secondSkill.gameObject.SetActive(false);
        dodgeSkill.gameObject.SetActive(false);
        basic.gameObject.SetActive(false);

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
            firstSkillIcon.sprite = character.Skills[characterData.skill1].skillIcon;
            secondSkillIcon.sprite = character.Skills[characterData.skill2].skillIcon;
            dodgeIcon.sprite = character.Dodge[characterData.dodge].skillIcon;
            ultimateIcon.sprite = character.Ultimate[characterData.ultimate].skillIcon;
        }
    }

}
