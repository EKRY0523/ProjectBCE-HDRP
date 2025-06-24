using UnityEngine;
using System.Collections.Generic;

public class ComponentHandler : EventHandler
{
    public EventHandler[] components;
    public Dictionary<Trait, EventHandler> componentDictionary = new();
    public PlayableCharacterData charData;
    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < components.Length; i++)
        {
            componentDictionary.Add(components[i].HandlerID,components[i]);
        }
        if(GetComponentInParent<PlayerMovement>())
        {
            componentDictionary.Add(GetComponentInParent<PlayerMovement>().HandlerID, GetComponentInParent<PlayerMovement>());
        }
    }

    public override void EnableComponent(Trait ID, bool enabled)
    {
        base.EnableComponent(ID, enabled);
        if(ID!=null)
        {
            if(componentDictionary.ContainsKey(ID))
            {
                componentDictionary[ID].enabled = enabled;
            }
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is PlayableCharacterData)
        {
            if(charData!=null)
            {
                Unsubscribe(charData.statemachine);
            }

            charData = (PlayableCharacterData)data;
            Subscribe(charData.statemachine);

        }
    }
}
