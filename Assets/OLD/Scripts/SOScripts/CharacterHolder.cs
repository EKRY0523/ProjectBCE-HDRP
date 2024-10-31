using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : ScriptableObject
{
    public AnimatorOverrideController overrideController;
    public int Level;
    public float exp;
    public float baseMaxHP,baseMaxENG,baseATK,baseEATK,baseSpeed,baseCSPD,baseDef,baseResist;
    public int STR, AGI, VIT, ENG, DEX, MTL; 
    public CharacterAbility[] ability;
    public BasicAttacks attack;
    
}
