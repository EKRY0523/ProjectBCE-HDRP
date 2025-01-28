using UnityEngine;
using System;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public int ID;
    [ColorUsage(true, true)]
    public Color charColor;

    public string characterName;
    public RenderTexture poseImage;
    public Sprite iconimage;
    public Material material;
    public string characterDetails;

    public Effect[] passive;
    public CharacterBasicAttack[] BasicAttack;
    public CharacterSkill[] Skills;
    public DodgeSkill[] Dodge;
    public UltimateSkill[] Ultimate;
    public Stat[] stats;
}
