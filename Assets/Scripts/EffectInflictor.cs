using UnityEngine;

public class EffectInflictor : MonoBehaviour
{
    public Effect effect;

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
        if(collision.collider.CompareTag("Player"))
        {
            Inflict(collision.gameObject.GetComponent<PartyHandler>().activeCharacter.GetComponent<EffectHandler>());
        }
    }
}
