using UnityEngine;
using System.Collections.Generic;
public class CharacterBasicAttack : CharacterSkill
{
    public float[] countMultiplier;
    public int MaxCount;
    public virtual void AttackCount(int count, StatMultiplier[] statIndex)
    {
    }
}
