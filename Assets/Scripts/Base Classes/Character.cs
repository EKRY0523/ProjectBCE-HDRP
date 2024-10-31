using UnityEngine;
using System;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public int ID;

    public RenderTexture poseImage;
    public Sprite iconimage;
    public Material material;

    public CharacterSkill[] BasicAttack;
    public CharacterSkill[] Skills;
    public CharacterSkill[] Dodge;
    public CharacterSkill[] Ultimate;
    public Stat[] stats;
}
