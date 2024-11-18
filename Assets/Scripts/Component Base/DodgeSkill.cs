using UnityEngine;

public class DodgeSkill : CharacterSkill
{
    public bool affectedByInput;
    public bool receiveHit;


    public virtual void OnHit(DodgeSkillHandler handler)
    {

    }
}
