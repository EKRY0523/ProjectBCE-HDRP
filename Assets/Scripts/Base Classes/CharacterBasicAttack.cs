using UnityEngine;
using System.Collections.Generic;
public class CharacterBasicAttack : CharacterSkill
{
    public float[] multiplier;
    public int MaxCount;
    public virtual void AttackCount(int count,Trait[] statIndex)
    {
    }
}
