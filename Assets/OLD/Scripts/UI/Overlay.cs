using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Overlay : MonoBehaviour
{
    public OldGameManager gameManager;
    [Header("Editable value UI")]
    [SerializeField] public Image currentHP;
    [SerializeField] public TextMeshProUGUI hpText;
    [SerializeField] public Image currentENG;
    [SerializeField] public TextMeshProUGUI engText;
    [SerializeField] public Image currentEXP;
    [SerializeField] public TextMeshProUGUI LevelText;
    [SerializeField] public TextMeshProUGUI EXPText;


    [SerializeField] Image basicAttack;
    [SerializeField] Image Skill1;
    [SerializeField] Image Skill2;
    [SerializeField] Image Ultimate;
    [SerializeField] Image Dodge;

    [Header("Buttons")]
    [SerializeField] Button Bag;
    [SerializeField] Button Quest;
    [SerializeField] Button Skill;
    [SerializeField] Button Stats;

    [SerializeField] UIManager uiManager;
    [SerializeField] OldPlayer player;

    [Header("Cooldown Stuff")]
    [SerializeField] Image Skill1CD;
    [SerializeField] Image Skill2CD;
    [SerializeField] Image UltimateCD;
    [SerializeField] TextMeshProUGUI Skill1CDText;
    [SerializeField] TextMeshProUGUI Skill2CDText;
    [SerializeField] TextMeshProUGUI UltimateCDText;

    public float cdValue1;
    public float cdValue2;
    public float cdValue3;

    //private void Start()
    //{
    //    gameManager = GameManager.instance;
    //    player = Player.instance;

    //    Invoke(nameof(initialize), 0.3f);

    //    //Bag.onClick.AddListener(uiManager.turnOnInventory);
    //    //Quest.onClick.AddListener(uiManager.turnOnQuestMenu);
    //    //Skill.onClick.AddListener(uiManager.turnOnSkillTreeSelect);
    //    //Stats.onClick.AddListener(uiManager.turnOnStatMenu);
    //}

    //private void Update()
    //{

    //    if (cdValue1 > 0)
    //    {
    //        cdValue1 -= Time.deltaTime;
    //        Skill1CD.gameObject.SetActive(true);
    //        Skill1CDText.gameObject.SetActive(true);
    //        Skill1CDText.text = cdValue1.ToString("F2");
    //        Skill1CD.fillAmount = cdValue1 / Player.instance.characterHolder.ability[0].cooldown;
    //    }
    //    else
    //    {
    //        Skill1CD.gameObject.SetActive(false);
    //        Skill1CDText.gameObject.SetActive(false);
    //    }


    //    if (cdValue2 > 0)
    //    {
    //        cdValue2 -= Time.deltaTime;
    //        Skill2CD.gameObject.SetActive(true);
    //        Skill2CDText.gameObject.SetActive(true);
    //        Skill2CDText.text = cdValue2.ToString("F2");
    //        Skill2CD.fillAmount = cdValue2 / Player.instance.characterHolder.ability[1].cooldown;
    //    }
    //    else
    //    {
    //        Skill2CD.gameObject.SetActive(false);
    //        Skill2CDText.gameObject.SetActive(false);
    //    }

    //    if (cdValue3 > 0)
    //    {
    //        cdValue3 -= Time.deltaTime;
    //        UltimateCD.gameObject.SetActive(true);
    //        UltimateCDText.gameObject.SetActive(true);
    //        UltimateCDText.text = cdValue3.ToString("F2");
    //        UltimateCD.fillAmount = cdValue3 / Player.instance.characterHolder.ability[2].cooldown;
    //    }
    //    else
    //    {
    //        UltimateCD.gameObject.SetActive(false);
    //        UltimateCDText.gameObject.SetActive(false);
    //    }



    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        Player.instance.input.playerActions.Disable();
    //        Cursor.lockState = CursorLockMode.None;
    //        Cursor.visible = true;
    //    }
    //    else if (Input.GetKeyUp(KeyCode.LeftShift))
    //    {
    //        Player.instance.input.playerActions.Enable();

    //        Cursor.lockState = CursorLockMode.Locked;
    //        Cursor.visible = false;
    //    }
    //    hpSlider.value = gameManager.currentHP / gameManager.MAXHP;
    //    energySlider.value = gameManager.currentENG / gameManager.MAXENG;
    //    LevelText.text = "LV" + Player.instance.level.ToString();
    //    hpText.text = Player.instance.currentHP.ToString();
    //    energyText.text = Player.instance.currentENG.ToString();

    //}

    //private void OnEnable()
    //{
    //    //initialize();
    //    if (player && !Player.instance.input.playerActions.enabled)
    //    {

    //        Player.instance.input.playerActions.Enable();

    //        Cursor.lockState = CursorLockMode.Locked;
    //        Cursor.visible = false;

    //    }

    //    uiManager.inventory.SetActive(false);
    //    uiManager.questMenu.SetActive(false);
    //    uiManager.skillTreeSelection.SetActive(false);
    //    uiManager.statMenu.SetActive(false);
    //    uiManager.backButton.gameObject.SetActive(false);

    //    if (gameManager)
    //    {
    //        basicAttack.sprite = gameManager.currentBasicAttack.attackIcon;
    //        Skill1.sprite = gameManager.skill1.skillIcon;
    //        Skill2.sprite = gameManager.skill2.skillIcon;
    //        Ultimate.sprite = gameManager.Ultimate.skillIcon;
    //        Dodge.sprite = gameManager.Dodge.skillIcon;
    //    }

    //}

    //private void OnDisable()
    //{
    //    player.input.playerActions.Disable();
    //}

    //public void initialize()
    //{
    //    LevelText.text = "Lv" + Player.instance.level.ToString();
    //    hpText.text = Player.instance.currentHP.ToString();
    //    energyText.text = Player.instance.currentENG.ToString();
    //    basicAttack.sprite = Player.instance.characterHolder.attack.attackIcon;
    //    Skill1.sprite = Player.instance.characterHolder.ability[0].skillIcon;
    //    Skill2.sprite = Player.instance.characterHolder.ability[1].skillIcon;
    //    Ultimate.sprite = Player.instance.characterHolder.ability[2].skillIcon;
    //    Dodge.sprite = Player.instance.characterHolder.ability[3].skillIcon;
    //}
}

