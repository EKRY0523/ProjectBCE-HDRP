using UnityEngine;

public class DodgeSkill : CharacterSkill
{
    public bool affectedByInput;
    public bool receiveHit;
    public GameObject hitIndication;
    public bool instantCheck;

    public virtual void OnHit(DodgeSkillHandler handler)
    {

    }
}
