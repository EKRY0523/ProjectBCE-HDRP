using UnityEngine;
using System;
using UnityEngine.Audio;
public class PlayableCharacterData : Entity
{
    public AudioSource source;
    public AudioClip[] footsteps;
    public int footstepIndex;

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
        

        InitializeCharacter();
    }

    public void InitializeCharacter()
    {
        for (int i = 0; i < stats.Count; i++)
        {
            if(!statDictionary.ContainsKey(character.stats[i].statIdentifier))
            {
                statDictionary.Add(character.stats[i].statIdentifier, stats[i]);
            }
        }
        basic.basicAttack = character.BasicAttack[basicAttack];
        firstSkill.Skill1 = character.Skills[skill1];
        secondSkill.Skill2 = character.Skills[skill2];
        dodgeSkill.dodge = character.Dodge[dodge];
        ultimateSkill.ultimate = character.Ultimate[ultimate];
        basic.basicAttack.OnSetup(this);
        firstSkill.Skill1.OnSetup(this);
        secondSkill.Skill2.OnSetup(this);
        dodgeSkill.dodge.OnSetup(this);
        ultimateSkill.ultimate.OnSetup(this);

    }

    public void PlayFootStepSound(int index)
    {
        source.PlayOneShot(footsteps[index]);
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
        ExpNeeded = 100 * MathF.Pow(1.5f,lv);
        if(currentEXP>=ExpNeeded)
        {
            lv += 1;
            currentEXP -= ExpNeeded;

            ExpNeeded = 100 * MathF.Pow(1.5f, lv);
            for (int i = 0; i < stats.Count; i++)
            {
                stats[i].MinMaxValue[1] = character.stats[i].MinMaxValue[1] * stats[i].statScaling * lv;
                stats[i].statValue = stats[i].MinMaxValue[1];
                MBEvent?.Invoke(stats[i].statIdentifier, stats[i].statValue);
            }
            if (currentEXP>= ExpNeeded)
            {
                LevelUp();

            }
        }

        MBEvent?.Invoke(null, lv);
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
