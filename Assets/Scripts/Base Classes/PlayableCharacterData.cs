using UnityEngine;
using System;

public class PlayableCharacterData : Entity
{
    public bool unlocked;
    public Statemachine statemachine;
    public Character character;
    public CharacterSkill[] skill;
    public CharacterSkill dodgeSkill;
    public CharacterSkill Ultimate;
    public override void Awake()
    {

        statemachine = GetComponent<Statemachine>();
        if (GameManager.instance != null)
        {
            if (GameManager.instance.CheckExistCharacter(character))
            {
                
                GameManager.instance.LoadCharacterData(this, character);

                for (int i = 0; i < stats.Count; i++)
                {
                    if (!statDictionary.ContainsKey(stats[i].statIdentifier))
                    {
                        statDictionary.Add(stats[i].statIdentifier, stats[i]);
                    }
                }
            }
            else
            {
                level.lv = 1;
                level.currentExp = 0;
                level.LevelUp();
                for (int i = 0; i < character.stats.Length; i++)
                {
                    placeholder[i] = character.stats[i];
                    stats[i] = placeholder[i];
                    if (!statDictionary.ContainsKey(stats[i].statIdentifier))
                    {
                        statDictionary.Add(stats[i].statIdentifier, stats[i]);
                    }
                }


                GameManager.instance.SaveCharacterData(this, character);
            }
        }


        base.Awake();
    }

    private void Start()
    {
        
        
    }

    private void OnEnable()
    {
        //skill[0].OnSetup();
        //skill[1].OnSetup();
        //dodgeSkill.OnSetup();
        //Ultimate.OnSetup();
    }

    private void OnDisable()
    {
        //skill[0].OnRemove();
        //skill[1].OnRemove();
        //dodgeSkill.OnRemove();
        //Ultimate.OnRemove();
    }

    private void Update()
    {

    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        GameManager.instance.SaveCharacterData(this,character);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
    }
}
