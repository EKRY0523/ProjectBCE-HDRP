using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class SkillPath : ScriptableObject
{

    [SerializeField] string skillOwner;
    [SerializeField] string skillPathName;
    [SerializeField] Sprite SkillPathIcon;
    [SerializeField] CharacterAbility[] abilities;
    [SerializeField] BasicAttacks basicAttack;
}
