
using UnityEngine;

[CreateAssetMenu(fileName = "RangedDecision", menuName = "EnemyDecision/RangedDecision")]
public class RangeBasedDecision : EnemyAttackDecision
{
    public bool moreThanRange;
    public float range;
    public override bool AttackCondition(Transform target, Entity entity)
    {
        if (moreThanRange)
        {
            if (Vector3.Distance(target.position, entity.transform.position) >= range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (Vector3.Distance(target.position, entity.transform.position) <= range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}