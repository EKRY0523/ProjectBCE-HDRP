using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatPanel : MonoBehaviour
{
    //[SerializeField] Slider[] derivedStatSliders;
    //[SerializeField] TextMeshProUGUI[] derivedStatValue;
    //[SerializeField] TextMeshProUGUI[] statValue;
    //[SerializeField] TextMeshProUGUI availableSP;
    //[SerializeField] Button[] addStatButton;
    //[SerializeField] TextMeshProUGUI HPValue, ENGValue,lvValue;

    //[SerializeField] UIManager uiManager;

    //public float ATK, SPD, DEF, EATK, CSPD, RST;
    //public int STR, AGI, VIT, ENG, DEX, MTL;
    //public int availSP;
    //GameManager gameManager;
    //Player player;
    //void Start()
    //{
    //    gameManager = GameManager.instance;
    //    if (gameManager)
    //    {
    //        ATK = gameManager.ATK;
    //        SPD = gameManager.Speed;
    //        DEF = gameManager.Def;
    //        EATK = gameManager.EATK;
    //        CSPD = gameManager.CSPD;
    //        RST = gameManager.Resist;

    //        STR = gameManager.STR;
    //        AGI = gameManager.AGI;
    //        VIT = gameManager.VIT;
    //        ENG = gameManager.ENG;
    //        DEX = gameManager.DEX;
    //        MTL = gameManager.MTL;

    //        availSP = player.availableStatPoints;

    //        availableSP.text = availSP.ToString();

    //        derivedStatValue[0].text = ATK.ToString();
    //        derivedStatValue[1].text = SPD.ToString();
    //        derivedStatValue[2].text = DEF.ToString();
    //        derivedStatValue[3].text = EATK.ToString();
    //        derivedStatValue[4].text = CSPD.ToString();
    //        derivedStatValue[5].text = RST.ToString();

    //        derivedStatSliders[0].value = ATK / 1000;
    //        derivedStatSliders[1].value = SPD / 100;
    //        derivedStatSliders[2].value = DEF / 500;
    //        derivedStatSliders[3].value = EATK / 1000;
    //        derivedStatSliders[4].value = CSPD / 100;
    //        derivedStatSliders[5].value = RST / 500;

    //        statValue[0].text = STR.ToString();
    //        statValue[1].text = AGI.ToString();
    //        statValue[2].text = VIT.ToString();
    //        statValue[3].text = ENG.ToString();
    //        statValue[4].text = DEX.ToString();
    //        statValue[5].text = MTL.ToString();
    //        HPValue.text = Player.instance.MAXHP.ToString();
    //        ENGValue.text = Player.instance.MAXENG.ToString();
    //        lvValue.text = "LV" + Player.instance.level.ToString();
    //    }

    //    addStatButton[0].onClick.AddListener(addSTR);
    //    addStatButton[1].onClick.AddListener(addAGI);
    //    addStatButton[2].onClick.AddListener(addVIT);
    //    addStatButton[3].onClick.AddListener(addENG);
    //    addStatButton[4].onClick.AddListener(addDEX);
    //    addStatButton[5].onClick.AddListener(addMTL);


    //    //Invoke(nameof(initialize), 1f);

    //}

    //private void Update()
    //{
    //    showButtons();
    //}

    //private void OnEnable()
    //{
    //    //initialize();
    //    player = Player.instance;
    //    //ATK = gameManager.ATK;
    //    //SPD = gameManager.Speed;
    //    //DEF = gameManager.Def;
    //    //EATK = gameManager.EATK;
    //    //CSPD = gameManager.CSPD;
    //    //RST = gameManager.Resist;

    //    //STR = gameManager.STR;
    //    //AGI = gameManager.AGI;
    //    //VIT = gameManager.VIT;
    //    //ENG = gameManager.ENG;
    //    //DEX = gameManager.DEX;
    //    //MTL = gameManager.MTL;
    //    player.input.playerActions.Disable();


    //    //availableSP.text = availSP.ToString();

    //    //derivedStatValue[0].text = ATK.ToString();
    //    //derivedStatValue[1].text = SPD.ToString();
    //    //derivedStatValue[2].text = DEF.ToString();
    //    //derivedStatValue[3].text = EATK.ToString();
    //    //derivedStatValue[4].text = CSPD.ToString();
    //    //derivedStatValue[5].text = RST.ToString();

    //    //derivedStatSliders[0].value = ATK / 1000;
    //    //derivedStatSliders[1].value = SPD / 100;
    //    //derivedStatSliders[2].value = DEF / 500;
    //    //derivedStatSliders[3].value = EATK / 1000;
    //    //derivedStatSliders[4].value = CSPD / 100;
    //    //derivedStatSliders[5].value = RST / 500;

    //    //statValue[0].text = STR.ToString();
    //    //statValue[1].text = AGI.ToString();
    //    //statValue[2].text = VIT.ToString();
    //    //statValue[3].text = ENG.ToString();
    //    //statValue[4].text = DEX.ToString();
    //    //statValue[5].text = MTL.ToString();
    //    //HPValue.text = Player.instance.MAXHP.ToString();
    //    //ENGValue.text = Player.instance.MAXENG.ToString();
    //    //lvValue.text = "LV" + Player.instance.level.ToString();
    //    Player.instance.initializeStat();
    //    initialize();
    //}

    //void initialize()
    //{
    //    ATK = Player.instance.ATK;
    //    SPD = Player.instance.Speed;
    //    DEF = Player.instance.Def;
    //    EATK = Player.instance.EATK;
    //    CSPD = Player.instance.CSPD;
    //    RST = Player.instance.Resist;

    //    STR = Player.instance.characterHolder.STR;
    //    AGI = Player.instance.characterHolder.AGI;
    //    VIT = Player.instance.characterHolder.VIT;
    //    ENG = Player.instance.characterHolder.ENG;
    //    DEX = Player.instance.characterHolder.DEX;
    //    MTL = Player.instance.characterHolder.MTL;

    //    availSP = Player.instance.availableStatPoints;

    //    availableSP.text = availSP.ToString();

    //    derivedStatValue[0].text = ATK.ToString();
    //    derivedStatValue[1].text = SPD.ToString();
    //    derivedStatValue[2].text = DEF.ToString();
    //    derivedStatValue[3].text = EATK.ToString();
    //    derivedStatValue[4].text = CSPD.ToString();
    //    derivedStatValue[5].text = RST.ToString();

    //    derivedStatSliders[0].value = ATK / 1000;
    //    derivedStatSliders[1].value = SPD / 100;
    //    derivedStatSliders[2].value = DEF / 500;
    //    derivedStatSliders[3].value = EATK / 1000;
    //    derivedStatSliders[4].value = CSPD / 100;
    //    derivedStatSliders[5].value = RST / 500;

    //    statValue[0].text = STR.ToString();
    //    statValue[1].text = AGI.ToString();
    //    statValue[2].text = VIT.ToString();
    //    statValue[3].text = ENG.ToString();
    //    statValue[4].text = DEX.ToString();
    //    statValue[5].text = MTL.ToString();
    //    HPValue.text = Player.instance.MAXHP.ToString();
    //    ENGValue.text = Player.instance.MAXENG.ToString();
    //    lvValue.text = "LV" + Player.instance.level.ToString();
    //}

    //void showButtons()
    //{
    //    if (availSP < 1)
    //    {
    //        for (int i = 0; i < addStatButton.Length; i++)
    //        {
    //            addStatButton[i].gameObject.SetActive(false);
    //        }
    //        return;
    //    }

    //    for (int i = 0; i < addStatButton.Length; i++)
    //    {
    //        addStatButton[i].gameObject.SetActive(true);
    //    }

    //}

    //void addSTR()
    //{
    //    player.characterHolder.STR += 1;
    //    player.initializeStat();
    //    initialize();
    //}

    //void addAGI()
    //{
    //    player.characterHolder.AGI += 1;
    //    player.initializeStat();
    //    initialize();
    //}
    
    //void addVIT()
    //{
    //    player.characterHolder.VIT += 1;
    //    Player.instance.currentHP = Player.instance.MAXHP;
    //    player.initializeStat();
    //    initialize();
    //}
    //void addENG()
    //{
    //    player.characterHolder.ENG += 1;
    //    Player.instance.currentENG = Player.instance.MAXENG;

    //    player.initializeStat();
        
    //    initialize();
    //}
    //void addDEX()
    //{
    //    player.characterHolder.DEX += 1;
    //    player.initializeStat();
    //    initialize();
    //}

    //void addMTL()
    //{
    //    player.characterHolder.MTL += 1;
    //    player.initializeStat();
    //    initialize();
    //}
}
