using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class OldGameManager : MonoBehaviour
{
    public static OldGameManager instance;

    private float _EXP;
    public float EXP
    {
        get
        {
            return _EXP;
        }
        set
        {
            float expNeeded;
            if (Level == 1)
            {
                expNeeded = 100 * MathF.Pow(2, Level - 2);
            }
            else
            {
                expNeeded = 100 * MathF.Pow(2, Level - 1);
            }

            UIManager.Instance.overlay.currentEXP.fillAmount = EXP / expNeeded;
            UIManager.Instance.overlay.EXPText.text = (UIManager.Instance.overlay.currentENG.fillAmount/1).ToString() + "%";

            if (value >= expNeeded)
            {
                Level += 1;
                _EXP -= expNeeded;
            }
        }
    }
    private int _Level;
    public int Level
    {
        get
        {
            if(_Level == 0)
            {
                return 1;
            }
            else
            {

                return _Level;
            }
        }
        set
        {
            _Level = value;
            UIManager.Instance.overlay.LevelText.text = "LV " + Level.ToString();
            
            
        }
    }

    public int availableStatPoints
    {
        get
        {
            return (Level * 3) - (STR + AGI + VIT + ENG + DEX + MTL);
        }
        set
        {
            
        }
    }
    public CharacterHolder BaseStats
    {
        get
        {
            return _Stat;
        }
        set
        {
            _Stat = value;
            _baseATK = value.baseATK;
            _baseEATK = value.baseEATK;
            _baseSPD = value.baseSpeed;
            _baseCSPD = value.baseCSPD;
            _baseDEF = value.baseDef;
            _baseRST = value.baseResist;
            _baseMAXHP = value.baseMaxHP;
            _baseMAXENG = value.baseMaxENG;
        }
    }
    private float _ATK, _EATK, _SPD, _CSPD, _DEF, _RST, _MAXHP, _MAXENG;
    private float _baseATK, _baseEATK, _baseSPD, _baseCSPD, _baseDEF, _baseRST, _baseMAXHP, _baseMAXENG;
    private BasicAttacks _basicAttacks;
    private CharacterAbility _skill1, _skill2, _dodge, _ultimate;
    public float ATK
    {
        get
        {
            return _baseATK;
        }
        set
        {
           _ATK = value +(Level * 50) + (STR * 3) + (DEX * 1.5f);
        }
    }
    public float EATK
    {
        get
        {
            return _baseEATK;
        }
        set
        {
            _EATK = value + (Level * 50) + (ENG * 4f) + (DEX * 1);
        }
    }
    public float SPD
    {
        get
        {
            return _baseSPD;
        }
        set
        {
            _SPD = value + Level + (AGI * 0.3f);
        }
    }
    public float CSPD
    {
        get
        {
            return _baseCSPD;
        }
        set
        {
            _CSPD = value + Level + (DEX * 0.5f);
            Debug.Log("works");
        }
    }
    public float DEF
    {
        get
        {
            return _baseDEF;
        }
        set
        {
            _DEF = value + (Level * 75) + (VIT * 5f); //* (characterHolder.Level);
        }
    }
    public float RST
    {
        get 
        {
            return _baseRST;
        }
        set
        {
            _RST = value + (Level * 75) + (MTL * 0.15f);
        }
    }
    public float MAXHP
    {
        get
        {
            return _baseMAXHP;
        }
        set
        {
            _MAXHP = value+(Level * 100) +(VIT * 2f);
            UIManager.Instance.overlay.hpText.text = currentHP.ToString() + "/" + MAXHP.ToString();
        }
    }
    public float MAXENG
    { 
        get
        {
            return _baseMAXENG;
        }
        set
        {

           _MAXENG = value + (Level * 100) + (ENG*3f);
            UIManager.Instance.overlay.engText.text = currentENG.ToString() + "/" + MAXENG.ToString();
        }
    }

    public int STR { get; set; }
    public int AGI { get; set; }
    public int VIT { get; set; }
    public int ENG { get; set; }
    public int DEX { get; set; }
    public int MTL { get; set; }

    private float _currentHP;
    private float _currentENG;
    public float currentHP
    {
        get
        {
            return _currentHP;
        }
        set
        {
            _currentHP = Mathf.Clamp(value, 0, MAXHP);
            UIManager.Instance.overlay.currentHP.fillAmount = currentHP / MAXHP;
            UIManager.Instance.overlay.hpText.text = currentHP.ToString() + "/" + MAXHP.ToString();
            if (currentHP <= 0)
            {
                //dieFunction
            }
        }
    }
    public float currentENG
    {
        get
        {
            return _currentENG;
        }
        set
        {
            _currentENG = Mathf.Clamp(value, 0, MAXENG);
            UIManager.Instance.overlay.currentENG.fillAmount = currentENG / MAXENG;
            UIManager.Instance.overlay.engText.text = currentENG.ToString() + "/" + MAXENG.ToString();
        }
    }


    [SerializeField] public List<BasicAttacks> Basics = new List<BasicAttacks>();
    [SerializeField] public List<CharacterAbility> Skills = new List<CharacterAbility>();
    [SerializeField] public List<CharacterAbility> Dodges = new List<CharacterAbility>();
    [SerializeField] public List<CharacterAbility> Ultimates = new List<CharacterAbility>();

    class saveData
    {
        public int Level;
        public float EXP;

        public CharacterHolder stat;
        public float currentHP,currentENG;
        public float maxHP,maxENG;
        private float ATK, EATK, SPD, CSPD, DEF, RST, MAXHP, MAXENG;



        public BasicAttacks Basic;
        public CharacterAbility Skill1;
        public CharacterAbility Skill2;
        public CharacterAbility Dodge;
        public CharacterAbility Ultimate;
        public Vector3 playerPos;
    }

    
    
    public BasicAttacks currentBasicAttack
    {
        get
        {
            return _basicAttacks;
        }
        set
        {
            _basicAttacks = value;
            OldPlayer.instance.Basic = value;
        }
    }
    public CharacterAbility skill1
    {
        get
        {
            return _skill1;
        }
        set
        {
            _skill1 = value;
            OldPlayer.instance.Skill1 = value;
        }
    }
    public CharacterAbility skill2
    {
        get
        {
            return _skill2;
        }
        set
        {
            _skill2 = value;
            OldPlayer.instance.Skill2 = value;
        }
    }
    public CharacterAbility Ultimate
    {
        get
        {
            return _ultimate;
        }
        set
        {
            _ultimate = value;
            OldPlayer.instance.Ultimate = value;
        }
    }
    public CharacterAbility Dodge
    {
        get
        {
            return _dodge;
        }
        set
        {
            _dodge = value;
            OldPlayer.instance.Dodge = value;
        }
    }

    private CharacterHolder _Stat;
    

    public CharacterHolder holderTest;
    private void Awake()
    {
        OldGameManager.instance = this;
       
    }
    private void Start()
    {
        BaseStats = OldPlayer.instance.characterHolder;
        
        loadData();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            loadData();
        }
    }
    public void Save()
    {
        saveData Data = new saveData();

        Data.Level = _Level;
        Data.EXP = _EXP;

        Data.stat = _Stat;
        Data.currentHP = _currentHP;
        Data.currentENG = _currentENG;

        Data.Basic = OldPlayer.instance.Basic;
        Data.Skill1 = OldPlayer.instance.Skill1;
        Data.Skill2 = OldPlayer.instance.Skill2;
        Data.Dodge = OldPlayer.instance.Dodge;
        Data.Ultimate = OldPlayer.instance.Ultimate;
        Data.playerPos = OldPlayer.instance.transform.position;
        string json = JsonUtility.ToJson(Data,true);
        File.WriteAllText(Application.dataPath + "/tESTsaVe.json", json);
        
    }

    public void loadData()
    {
        string json = File.ReadAllText(Application.dataPath + "/tESTsaVe.json");
        saveData Data = JsonUtility.FromJson<saveData>(json);

        if(Data.stat!=null)
        {
            Level = Data.Level;
            EXP = Data.EXP;

            BaseStats = Data.stat;
            ATK = Data.stat.baseATK;
            EATK = Data.stat.baseEATK;
            SPD = Data.stat.baseSpeed;
            CSPD = Data.stat.baseCSPD;
            DEF = Data.stat.baseDef;
            RST = Data.stat.baseResist;
            MAXHP = Data.stat.baseMaxHP;
            MAXENG = Data.stat.baseMaxENG;

            currentHP = Data.currentHP;
            currentENG = Data.currentENG;
        }
        


        currentBasicAttack = Data.Basic;
        skill1 = Data.Skill1;
        skill2 = Data.Skill2;
        Ultimate = Data.Ultimate;
        Dodge = Data.Dodge;
        OldPlayer.instance.transform.position = Data.playerPos;
    }

    //void initializeValue()
    //{
    //    ATK = _baseATK;
    //    MAXHP= _baseMAXHP;
    //}
}
