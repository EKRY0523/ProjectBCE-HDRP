using UnityEngine;

public class SkillObject : MonoBehaviour
{
    public TagHandle tagName;
    public Trait[] originStat; //what it derived from, so it can handle calculations properly like atk hitting hp, then it means -def then apply
    public Trait[] targetedStat;

    public PlayableCharacterData characterData; //to get reference of the caster for the stats
    public float multiplier;
    public float duration;
    //add effect caster here

    private void OnEnable()
    {
        Destroy(gameObject,duration);
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if(CompareTag(tagName))
        {
            if (other.GetComponent<StatHandler>())
            {
                other.GetComponent<StatHandler>().ReceiveValue(targetedStat,multiplier);
            }
        }
        
    }

    public virtual void OnCast()
    {
        
    }

    public virtual void OnDestroy()
    {

    }
}
