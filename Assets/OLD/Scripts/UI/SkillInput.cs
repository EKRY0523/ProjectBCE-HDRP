using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillInput : MonoBehaviour
{
    //[SerializeField] List<BasicAttacks> Basics = new List<BasicAttacks>();
    //[SerializeField] List<CharacterAbility> Skills = new List<CharacterAbility>();
    //[SerializeField] List<CharacterAbility> Dodges = new List<CharacterAbility>();
    //[SerializeField] List<CharacterAbility> Ultimates = new List<CharacterAbility>();
    //[SerializeField] UIManager uiManager;
    //public GameManager gameManager{get;set;} 

    //List<TMP_Dropdown.OptionData> basicsData = new List<TMP_Dropdown.OptionData>();
    //List<TMP_Dropdown.OptionData> skillsData = new List<TMP_Dropdown.OptionData>();
    //List<TMP_Dropdown.OptionData> dodgesData = new List<TMP_Dropdown.OptionData>();
    //List<TMP_Dropdown.OptionData> UltimatesData = new List<TMP_Dropdown.OptionData>();

    //[Header("Dropdown")]
    //[SerializeField] TMP_Dropdown basicAttack;
    //[SerializeField] TMP_Dropdown dodge;
    //[SerializeField] TMP_Dropdown Skill1;
    //[SerializeField] TMP_Dropdown Skill2;
    //[SerializeField] TMP_Dropdown Ultimate;

    //[Header("Icons")]
    //[SerializeField] Image basicIcon;
    //[SerializeField] Image dodgeIcon;
    //[SerializeField] Image Skill1Icon;
    //[SerializeField] Image Skill2Icon;
    //[SerializeField] Image UltimateIcon;

    //void Start()
    //{
    //    if(!gameManager)
    //    {
    //        gameManager = GameManager.instance;
    //    }
        
    //    if (gameManager)
    //    {
    //        Basics = gameManager.Basics;
    //        Skills = gameManager.Skills;
    //        Dodges = gameManager.Dodges;
    //        Ultimates = gameManager.Ultimates;
    //    }
    //    //Invoke(nameof(initialize),1f);
    //    basicAttack.onValueChanged.AddListener(delegate { changeBasic(basicAttack); });
    //    dodge.onValueChanged.AddListener(delegate { changeDodge(dodge); });
    //    Skill1.onValueChanged.AddListener(delegate { changeS1(Skill1); });
    //    Skill2.onValueChanged.AddListener(delegate { changeS2(Skill2); });
    //    Ultimate.onValueChanged.AddListener(delegate { changeULT(Ultimate); });
    //}

    //void Update()
    //{
    //    refresh();
    //}
    //private void OnEnable()
    //{
    //    uiManager.overlay.SetActive(false);
    //    if (gameManager)
    //    {
    //        Basics = gameManager.Basics;
    //        Skills = gameManager.Skills;
    //        Dodges = gameManager.Dodges;
    //        Ultimates = gameManager.Ultimates;
    //    }
    //    initialize();
    //    //foreach (BasicAttacks basicAttack in Basics)
    //    //{
    //    //    //if(basicAttack)
    //    //    basicsData.Add(new TMP_Dropdown.OptionData(basicAttack.attackName, basicAttack.attackIcon));
    //    //}
    //    //foreach (CharacterAbility dodge in Dodges)
    //    //{
            
    //    //    dodgesData.Add(new TMP_Dropdown.OptionData(dodge.SkillName, dodge.skillIcon));
    //    //}
    //    //foreach (CharacterAbility skill in Skills)
    //    //{   
    //    //    if(skill.skillLevel >0)
    //    //    {
    //    //        skillsData.Add(new TMP_Dropdown.OptionData(skill.SkillName, skill.skillIcon));
    //    //    }
            
    //    //}
    //    //foreach(CharacterAbility ultimate in Ultimates)
    //    //{
    //    //    if (ultimate.skillLevel > 0)
    //    //    {
    //    //        UltimatesData.Add(new TMP_Dropdown.OptionData(ultimate.SkillName, ultimate.skillIcon));
    //    //    }
    //    //}
        
    //    basicAttack.AddOptions(basicsData);
    //    dodge.AddOptions(dodgesData);
    //    Skill1.AddOptions(skillsData);
    //    Skill2.AddOptions(skillsData);
    //    Ultimate.AddOptions(UltimatesData);

    //    //Invoke(nameof(refresh),1f);
    //}
    
    //private void OnDisable()
    //{
    //    basicsData.Clear();
    //    dodgesData.Clear();
    //    skillsData.Clear();
    //    UltimatesData.Clear();

    //    basicAttack.ClearOptions();
    //    dodge.ClearOptions();
    //    Skill1.ClearOptions();
    //    Skill2.ClearOptions();
    //    Ultimate.ClearOptions();

    //    //basicAttack.onValueChanged.RemoveAllListeners();
    //    //dodge.onValueChanged.RemoveAllListeners();
    //    //Skill1.onValueChanged.RemoveAllListeners();
    //    //Skill2.onValueChanged.RemoveAllListeners();
    //    //Ultimate.onValueChanged.RemoveAllListeners();
        
    //}

    //public void initialize()
    //{
    //    gameManager = GameManager.instance;

    //    basicsData.Clear();
    //    dodgesData.Clear();
    //    skillsData.Clear();
    //    UltimatesData.Clear();

    //    basicAttack.ClearOptions();
    //    dodge.ClearOptions();
    //    Skill1.ClearOptions();
    //    Skill2.ClearOptions();
    //    Ultimate.ClearOptions();


    //    Basics = gameManager.Basics;
    //    Skills = gameManager.Skills;
    //    Dodges = gameManager.Dodges;
    //    Ultimates = gameManager.Ultimates;

        

    //    foreach (BasicAttacks basicAttack in Basics)
    //    {
    //        basicsData.Add(new TMP_Dropdown.OptionData(basicAttack.attackName, basicAttack.attackIcon));
    //    }
    //    foreach (CharacterAbility dodge in Dodges)
    //    {

    //        dodgesData.Add(new TMP_Dropdown.OptionData(dodge.SkillName, dodge.skillIcon));
    //    }
    //    foreach (CharacterAbility skill in Skills)
    //    {
    //        if (skill.skillLevel > 0)
    //        {
    //            skillsData.Add(new TMP_Dropdown.OptionData(skill.SkillName, skill.skillIcon));
    //        }

    //    }
    //    foreach (CharacterAbility ultimate in Ultimates)
    //    {
    //        if (ultimate.skillLevel > 0)
    //        {
    //            UltimatesData.Add(new TMP_Dropdown.OptionData(ultimate.SkillName, ultimate.skillIcon));
    //        }
    //    }
    //    //refresh();
    //    basicIcon.sprite = Player.instance.characterHolder.attack.attackIcon;
    //    Skill1Icon.sprite = Player.instance.characterHolder.ability[0].skillIcon;
    //    Skill2Icon.sprite = Player.instance.characterHolder.ability[1].skillIcon;
    //    UltimateIcon.sprite = Player.instance.characterHolder.ability[2].skillIcon;
    //    dodgeIcon.sprite = Player.instance.characterHolder.ability[3].skillIcon;
    //}

    //void changeBasic(TMP_Dropdown basic)
    //{
    //    foreach (BasicAttacks newBasic in Basics)
    //    {
    //        if(newBasic.attackName == basicAttack.options[basic.value].text)
    //        {
    //            Player.instance.characterHolder.attack = newBasic;
    //        }
    //    }
    //    basicIcon.sprite = Player.instance.characterHolder.attack.attackIcon;
    //    //uiManager.overlay.GetComponent<Overlay>().initialize();
    //}

    //void changeDodge(TMP_Dropdown dodge)
    //{
    //    foreach (CharacterAbility newDodge in Dodges)
    //    {
    //        if (newDodge.SkillName == dodge.options[dodge.value].text)
    //        {
    //            Player.instance.characterHolder.ability[3] = newDodge;
    //        }
    //    }
    //    dodgeIcon.sprite = Player.instance.characterHolder.ability[3].skillIcon;
    //    //uiManager.overlay.GetComponent<Overlay>().initialize();
    //}

    //void changeS1(TMP_Dropdown S1)
    //{
    //    foreach (CharacterAbility newS1 in Skills)
    //    {
    //        if (newS1.SkillName == S1.options[S1.value].text)
    //        {
    //            Player.instance.characterHolder.ability[0] = newS1;
    //        }
    //    }
    //    Skill1Icon.sprite = Player.instance.characterHolder.ability[0].skillIcon;
    //    //uiManager.overlay.GetComponent<Overlay>().initialize();
    //}

    //void changeS2(TMP_Dropdown S2)
    //{
    //    foreach (CharacterAbility newS2 in Skills)
    //    {
    //        if (newS2.SkillName == S2.options[S2.value].text)
    //        {
    //            Player.instance.characterHolder.ability[1] = newS2;
    //        }
    //    }

    //    Skill2Icon.sprite = Player.instance.characterHolder.ability[1].skillIcon;
    //    //uiManager.overlay.GetComponent<Overlay>().initialize();
    //}

    //void changeULT(TMP_Dropdown ult)
    //{
    //    foreach (CharacterAbility newUlt in Skills)
    //    {
    //        if (newUlt.SkillName == ult.options[ult.value].text)
    //        {
    //            gameManager.player.characterHolder.ability[2] = newUlt;
    //        }
    //    }
    //    UltimateIcon.sprite = Player.instance.characterHolder.ability[2].skillIcon;
    //    //uiManager.overlay.GetComponent<Overlay>().initialize();
    //}

    //void refresh()
    //{
    //    basicAttack.RefreshShownValue();
    //    dodge.RefreshShownValue();
    //    Skill1.RefreshShownValue();
    //    Skill2.RefreshShownValue();
    //    Ultimate.RefreshShownValue();
    //}
}
