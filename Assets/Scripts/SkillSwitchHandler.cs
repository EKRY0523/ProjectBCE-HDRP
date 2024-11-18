using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SkillSwitchHandler : EventHandler
{
    public PlayableCharacterData characterData;
    public Character character;
    public CurrentSkill skill;

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
        if(character!=null)
        {
            LoadData();
        }
    }

    private void OnEnable()
    {
        if(character!=null)
        {

            LoadData();
        }
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
    public void LoadData()
    {
        skill = JsonUtility.FromJson<CurrentSkill>(File.ReadAllText(Application.dataPath + "/CharacterSaveFile/" + character.name + ".json"));
        MBEvent?.Invoke(null, character);
        basic.character = character;
        basic.currentSkillIndex = skill.basicAttack;

        firstSkill.character = character;
        firstSkill.currentSkillIndex = skill.skill1;
        firstSkill.secondary = skill.skill2;

        secondSkill.character = character;
        secondSkill.currentSkillIndex = skill.skill2;
        secondSkill.secondary = skill.skill1;

        dodgeSkill.character = character;
        dodgeSkill.currentSkillIndex = skill.dodge;

        ultimateSkill.character = character;
        ultimateSkill.currentSkillIndex = skill.dodge;
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Character)
        {
            characterData = GameManager.instance.characterDictionary[(Character)data];
            character = (Character)data;
            LoadData();
            //skill = JsonUtility.FromJson<CurrentSkill>(File.ReadAllText(Application.dataPath + "/CharacterSaveFile/" + character.name + ".json"));

            basicIcon.sprite = character.BasicAttack[skill.basicAttack].skillIcon;
            firstSkillIcon.sprite = character.Skills[skill.skill1].skillIcon;
            secondSkillIcon.sprite = character.Skills[skill.skill2].skillIcon;
            dodgeIcon.sprite = character.Dodge[skill.dodge].skillIcon;
            ultimateIcon.sprite = character.Ultimate[skill.ultimate].skillIcon;

            MBEvent?.Invoke(null, character);
        }
        //if(ID == ComponentsID[0])
        //{
        //    skill.basicAttack = (int)data;
        //}
        //if (ID == ComponentsID[1])
        //{

        //}
        //if (ID == ComponentsID[2])
        //{

        //}
        //if (ID == ComponentsID[3])
        //{

        //}
        //if (ID == ComponentsID[4])
        //{

        //}
    }

}
