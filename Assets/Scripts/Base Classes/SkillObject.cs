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
    public bool detachFromParent;
    public GameObject hitFX;
    public bool friendly;
    //add effect caster here

    private void OnEnable()
    {
        this.tag = "SkillObject";
        Destroy(gameObject,duration);
        if (detachFromParent)
        {
            Invoke(nameof(Detach), 0.1f);
        }

    }


    public void Detach()
    {
        transform.parent = null;
    }
    private void Start()
    {
        //if (transform.parent != null)
        //{
        //    transform.rotation = transform.parent.rotation;
        //}
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(tagName == "Enemy")
        {
            if (other.CompareTag(tagName))
            {
                if(!friendly)
                {
                    if(hitFX!=null)
                    {
                        //Vector3 otherObjCenter = other.transform.TransformPoint(other.bounds.center);
                        Destroy(Instantiate(hitFX, other.bounds.center, Quaternion.identity,other.transform),1f);
                    }
                }
                if (other.GetComponent<StatHandler>())
                {
                    StatHandler stathandle = other.GetComponent<StatHandler>();
                    stathandle.ReceiveValue(targetedStat, originStat, -multiplier);
                    if (knockback != null)
                    {

                        stathandle.ReceiveKnockback(this.transform, knockback);
                    }
                }

            }

        }
        
        else if (tagName == "Player")
        {
            if (other.CompareTag(tagName))
            {
                if (other.GetComponent<PartyHandler>())
                {
                    StatHandler stathandle = other.GetComponent<PartyHandler>().activeCharacter.statHandler;
                    stathandle.ReceiveValue(targetedStat, originStat, -multiplier);
                    //Debug.Log("hit");
                }
            }

        }

    }

    public virtual void OnCast()
    {
    }

}
