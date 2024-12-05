using UnityEngine;

public class EffectInflictor : EventHandler
{
    public Effect effect;
    public bool dualTag;

    public PlayerInput input;
    public string effectedTag;


    public enum TargetType
    {
        Global,Targeted
    }
    public TargetType type;


    public virtual void Inflict(EffectHandler target)
    {
        //if (type == EffectInflictor.TargetType.Global)
        //{
        //    for (int i = 0; i < target.party.party.Count; i++)
        //    {
        //        target.party.party[i].GetComponent<EffectHandler>().OnAddEffect(effect);
        //    }
            
           
        //}
        //else
        //{
            target.OnAddEffect(effect);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("normal");
            if (collision.gameObject.GetComponent<PartyHandler>())
            {
                PartyHandler party = collision.gameObject.GetComponent<PartyHandler>();
                if (type == EffectInflictor.TargetType.Global)
                {
                    for (int i = 0; i < party.party.Count; i++)
                    {
                        Inflict(party.party[i].GetComponent<EffectHandler>());
                    }
                }
                else
                {
                    Inflict(party.activeCharacter.GetComponent<EffectHandler>());

                }
            }
        }

    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("controller");
            if (hit.gameObject.GetComponent<PartyHandler>())
            {
                PartyHandler party = hit.gameObject.GetComponent<PartyHandler>();
                if (type == EffectInflictor.TargetType.Global)
                {
                    for (int i = 0; i < party.party.Count; i++)
                    {
                        Inflict(party.party[i].GetComponent<EffectHandler>());
                    }
                }
                else
                {
                    Inflict(party.activeCharacter.GetComponent<EffectHandler>());

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (effectedTag == "Player")
        {
            if (other.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<PartyHandler>())
                {
                    Debug.Log("triggerer");
                    PartyHandler party = other.gameObject.GetComponent<PartyHandler>();
                    if (type == EffectInflictor.TargetType.Global)
                    {
                        for (int i = 0; i < party.party.Count; i++)
                        {
                            Inflict(party.party[i].GetComponent<EffectHandler>());
                        }
                    }
                    else
                    {
                        Inflict(party.activeCharacter.GetComponent<EffectHandler>());

                    }
                }
            }
        }
        else
        {
            if (other.CompareTag("Enemy"))
            {
                if(other.GetComponent<EffectHandler>())
                {

                    Inflict(other.gameObject.GetComponent<EffectHandler>());
                }
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
