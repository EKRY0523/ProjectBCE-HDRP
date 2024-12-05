using UnityEngine;

[CreateAssetMenu(fileName = "HPDecision", menuName = "EnemyDecision/HPDecision")]
public class HPBasedDecision : EnemyAttackDecision
{
    public Trait stat;
    public float threshold;
    public override bool AttackCondition(Transform target, Entity entity)
    {
        if (entity.statDictionary[stat].statValue < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}