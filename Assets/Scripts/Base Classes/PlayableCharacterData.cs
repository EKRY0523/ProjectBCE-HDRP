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

    public void OnUnlock()
    {
        unlocked = true;
        if (!GameManager.instance.UnlockedCharacters.Contains(GameManager.instance.characterLoading[character.ID]))
        {

            GameManager.instance.UnlockedCharacters.Add(GameManager.instance.characterLoading[character.ID]);
        }
    }

}
