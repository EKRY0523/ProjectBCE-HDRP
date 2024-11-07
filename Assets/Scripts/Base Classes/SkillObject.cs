using UnityEngine;

public class SkillObject : EventHandler
{
    public string tagName;
    public Trait[] originStat; //what it derived from, so it can handle calculations properly like atk hitting hp, then it means -def then apply
    public Trait[] targetedStat;

    public Entity characterData; //to get reference of the caster for the stats //just incase, its playablechardata
    public float multiplier;
    public float duration;
    public Transform target;
    public MovementData knockback;
    //add effect caster here

    private void OnEnable()
    {
        Destroy(gameObject,duration);
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagName))
        {
            if ( other.GetComponent<StatHandler>())
            {
                StatHandler stathandle = other.GetComponent<StatHandler>();
                stathandle.ReceiveValue(targetedStat,originStat,-multiplier);
                if(knockback!=null)
                {

                    stathandle.ReceiveKnockback(this.transform, knockback);
                }
            }
        }
        
    }

    public virtual void OnCast()
    {
    }

}
