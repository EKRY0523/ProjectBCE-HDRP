using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAbility : ScriptableObject
{
    //[SerializeField] AnimatorOverrideController animationClip;
    public enum category
    {
        skill,block,dodge,ultimate
    }
    public OldPlayer Player;
    [SerializeField] public category skillcategory;
    [SerializeField] public float skillCost;
    [SerializeField] CharacterAbility requiredSkill;
    [SerializeField][Range(0,5)] int requiredSkillLevel;
    [SerializeField] public string SkillName;
    [SerializeField] public Sprite skillIcon;
    [SerializeField] public float cooldown;
    [SerializeField][Range(0, 5)]public int skillLevel;
    [SerializeField] public AnimatorOverrideController skillAnimation;
    [SerializeField] float damage;

    public abstract void SkillUse();
    public abstract void SkillCooldown(int KeyPressed);

}
