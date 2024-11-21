using UnityEngine;
using System;

public class PlayableCharacterData : Entity
{
    public bool unlocked;
    public Statemachine statemachine;
    public Character character;
    public BasicAttackHandler basic;
    public FirstSkillHandler firstSkill;
    public SecondSkillHandler secondSkill;
    public DodgeSkillHandler dodgeSkill;
    public UltimateSkillHandler ultimateSkill;

    public CharacterStatusHandler characterStatus;

    public int basicAttack;
    public int skill1;
    public int skill2;
    public int dodge;
    public int ultimate;

    public override void Awake()
    {
        base.Awake();
        statemachine = GetComponent<Statemachine>();
        basic = GetComponent<BasicAttackHandler>();
        firstSkill = GetComponent<FirstSkillHandler>();
        secondSkill = GetComponent<SecondSkillHandler>();
        dodgeSkill = GetComponent<DodgeSkillHandler>();
        ultimateSkill = GetComponent<UltimateSkillHandler>();
        for (int i = 0; i < stats.Count; i++)
        {
            statDictionary.Add(stats[i].statIdentifier, stats[i]);
        }
        basic.basicAttack = character.BasicAttack[basicAttack];
        firstSkill.Skill1 = character.Skills[skill1];
        secondSkill.Skill2 = character.Skills[skill2];
        dodgeSkill.dodge = character.Dodge[dodge];
        ultimateSkill.ultimate = character.Ultimate[ultimate];
    }

    public void AddInParty()
    {
        characterStatus.gameObject.SetActive(true);
    }

    public void RemoveFromParty()
    {
        characterStatus.gameObject.SetActive(false);
    }
    public void ReceiveExp(float exp)
    {
        currentEXP += exp;
        MBEvent?.Invoke(null, currentEXP);
        if(currentEXP>ExpNeeded)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        if (lv == 1)
        {
            ExpNeeded = 100 * MathF.Pow(2, lv - 2);
        }
        else
        {
            ExpNeeded = 100 * MathF.Pow(2, lv - 1);
        }
        while (currentEXP >= ExpNeeded)
        {
            if (lv == 1)
            {
                ExpNeeded = 100 * MathF.Pow(2, lv - 2);
            }
            else
            {
                ExpNeeded = 100 * MathF.Pow(2, lv - 1);
            }

            if (currentEXP >= ExpNeeded)
            {
                lv += 1;
                currentEXP -= ExpNeeded;
                for (int i = 0; i < stats.Count; i++)
                {
                    stats[i].MinMaxValue[1] = character.stats[i].MinMaxValue[1] * MathF.Pow(stats[i].statScaling, lv - 1);
                    stats[i].statValue = stats[i].MinMaxValue[1];
                    MBEvent?.Invoke(stats[i].statIdentifier, stats[i].statValue);
                }
            }

            MBEvent?.Invoke(null, lv);
        }
    }

    private void Update()
    {
        //temp
        if(unlocked)
        {
            OnUnlock();
        }
    }
    public void OnUnlock()
    {
        unlocked = true;
        if (!GameManager.instance.UnlockedCharacters.Contains(GameManager.instance.characterLoading[character.ID]))
        {

            GameManager.instance.UnlockedCharacters.Add(GameManager.instance.characterLoading[character.ID]);
        }
    }

}
//    public override void Awake()
//    {

//        statemachine = GetComponent<Statemachine>();
//        basic = GetComponent<BasicAttackHandler>();
//        firstSkill = GetComponent<FirstSkillHandler>();
//        secondSkill = GetComponent<SecondSkillHandler>();
//        dodgeSkill = GetComponent<DodgeSkillHandler>();
//        ultimateSkill = GetComponent<UltimateSkillHandler>();

//        if (GameManager.instance != null)
//        {
//            if (GameManager.instance.CheckExistCharacter(character))
//            {

//                GameManager.instance.LoadCharacterData(this, character);

//                for (int i = 0; i < stats.Count; i++)
//                {
//                    if (!statDictionary.ContainsKey(stats[i].statIdentifier))
//                    {
//                        statDictionary.Add(stats[i].statIdentifier, stats[i]);
                       
//                    }
//                }
//            }
//            else
//            {
//                level.lv = 1;
//                level.currentExp = 0;
//                level.LevelUp();
//                for (int i = 0; i < character.stats.Length; i++)
//                {
//                    placeholder[i] = character.stats[i];
//                    stats[i] = placeholder[i];
//                    if (!statDictionary.ContainsKey(stats[i].statIdentifier))
//                    {
//                        statDictionary.Add(stats[i].statIdentifier, stats[i]);
//                    }
//                }


//                GameManager.instance.SaveCharacterData(this, character);
//            }

//            for (int i = 0; i < character.stats.Length; i++)
//            {
//                statDictionary[character.stats[i].statIdentifier].statAction = character.stats[i].statAction;
//                statDictionary[character.stats[i].statIdentifier].statScaling = character.stats[i].statScaling;
//                handleStat(character.stats[i].statIdentifier);
//            }
//        }

//        LoadCharacterData();
//        base.Awake();
//    }

//    public void LoadCharacterData()
//    {
//        GameManager.instance.LoadCharacterData(this,character);
//        basic.OnChangeSkill(character.BasicAttack[basicAttack]);
//        firstSkill.OnChangeSkill(character.Skills[skill1]);
//        secondSkill.OnChangeSkill(character.Skills[skill2]);
//        dodgeSkill.OnChangeSkill(character.Dodge[dodge]);
//        ultimateSkill.OnChangeSkill(character.Ultimate[ultimate]);
//    }
//    private void OnEnable()
//    {
//        MBEvent?.Invoke(null,level);
//        //skill[0].OnSetup();
//        //skill[1].OnSetup();
//        //dodgeSkill.OnSetup();
//        //Ultimate.OnSetup();
//    }

//    private void OnDisable()
//    {
//        //skill[0].OnRemove();
//        //skill[1].OnRemove();
//        //dodgeSkill.OnRemove();
//        //Ultimate.OnRemove();
//    }

//    private void Update()
//    {

//    }

//    public override void OnDestroy()
//    {
//        base.OnDestroy();
//        GameManager.instance.SaveCharacterData(this,character);
//    }

//    public override void OnGlobalEventInvoke(object data)
//    {
//        base.OnGlobalEventInvoke(data); //saving data in general just incase
//        if(data is null)
//        {
//            GameManager.instance.SaveCharacterData(this, character);
//        }
//        else if (data is PlayableCharacterData || data is Character)
//        {
//            LoadCharacterData();
//            //GameManager.instance.LoadCharacterData(this, character);
//        }
//    }

//    public override void OnInvoke(Trait ID, object data)
//    {
//        base.OnInvoke(ID, data);
//    }

//    public void ReceiveExp(float expMat)
//    {
//        level.currentExp += expMat;
//        level.LevelUp();
//        if(level.currentExp >= level.expNeeded)
//        {
//            statHandler.ResetStat();
//        }
        
//        MBEvent?.Invoke(null,level);
//    }
//}
