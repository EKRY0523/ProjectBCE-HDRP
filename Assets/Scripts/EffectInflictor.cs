using UnityEngine;

public class EffectInflictor : EventHandler
{
    public Effect effect;
    public bool dualTag;

    public string effectedTag;


    public enum TargetType
    {
        Global,Targeted
    }
    
    public TargetType type;
    public virtual void Inflict(EffectHandler target)
    {
        if (type == EffectInflictor.TargetType.Global)
        {
            for (int i = 0; i < target.party.characterList.Count; i++)
            {
                target.party.characterList[i].GetComponent<EffectHandler>().OnAddEffect(effect);
            }
            
           
        }
        else
        {
            target.OnAddEffect(effect);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(effectedTag == "Player")
        {
            if (collision.collider.CompareTag("Player"))
            {
                Inflict(collision.gameObject.GetComponent<PartyHandler>().activeCharacter.GetComponent<EffectHandler>());
            }
        }
        else
        {
            if(collision.collider.CompareTag("Enemy"))
            {
                Inflict(collision.gameObject.GetComponent<EffectHandler>());
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (effectedTag == "Player")
        {
            if (other.CompareTag("Player"))
            {
                if(other.gameObject.GetComponent<PartyHandler>())
                {
                    Inflict(other.gameObject.GetComponent<PartyHandler>().activeCharacter.GetComponent<EffectHandler>());
                }
            }
        }
        else
        {
            if (other.CompareTag("Enemy"))
            {
                Inflict(other.gameObject.GetComponent<EffectHandler>());
            }
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is float)
        {
            effect.value[0] = (float)data;
        }
    }
}
