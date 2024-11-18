using UnityEngine;
using System;
using System.Collections.Generic;

public interface ID
{

}

[Serializable]
public class Stat
{
    public Trait statIdentifier;
    public StatAction[] statAction;
    public float statValue;
    public float statScaling;
    public float[] MinMaxValue = new float[2];

    public bool followMax;

}
[Serializable]
public class Level
{
    public int lv;
    public float currentExp, expNeeded;
    public void LevelUp()
    {
        if (lv == 1)
        {
            expNeeded = 100 * MathF.Pow(2, lv - 2);
        }
        else
        {
            expNeeded = 100 * MathF.Pow(2, lv - 1);
        }

        if (currentExp >= expNeeded)
        {
            lv += 1;
            currentExp -= expNeeded;

        }
    }

}

[Serializable]
public class EventHandler : MonoBehaviour
{
    //MAY CHANGE TO BEHAVIOR ETC INSTEAD OF BOOL AND MAY USE SO BASED "ACCESS" TO REPLACE STRING ID
    public Trait HandlerID;
    public Trait[] ComponentsID; //used to turn shit on and off

    public CustomEvent[] SOEvent; //most likely used for game states 
    public List<EventHandler> eventListeners = new();
    public List<EventHandler> eventBroadcasters = new();

    public Action<Trait,object> MBEvent; //Monobehavior event
    public Action<Trait,bool> EnableComp;
    public Action<EventBroadcaster, MonoBehaviour,object> eventToExecute; //SOEvent

    public virtual void Awake()
    {
        //subscribe from listener side so broadcaster side wont have alot of stuff

        if(SOEvent!=null)
        {
            for (int i = 0; i < SOEvent.Length; i++)
            {
                SOEvent[i].globalEvent += OnGlobalEventInvoke;
            }
        }

        if (eventBroadcasters != null)
        {
            for (int i = 0; i < eventBroadcasters.Count; i++)
            {
                eventBroadcasters[i].eventListeners.Add(this);
                eventBroadcasters[i].MBEvent += OnInvoke;
                eventBroadcasters[i].EnableComp += EnableComponent;
            }
        }
    }

    public virtual void OnDestroy()
    {
        if (SOEvent != null)
        {
            for (int i = 0; i < SOEvent.Length; i++)
            {
                SOEvent[i].globalEvent -= OnGlobalEventInvoke;
            }
        }
        if (eventBroadcasters != null)
        {
            for (int i = 0; i < eventBroadcasters.Count; i++)
            {
                eventBroadcasters[i].eventListeners.Remove(this);
                eventBroadcasters[i].MBEvent -= OnInvoke;
                eventBroadcasters[i].EnableComp -= EnableComponent;
            }
        }
    }

    public void Subscribe(EventHandler broadcaster)
    {
        //Manual
        //subscribe from listener side so broadcaster side wont have alot of stuff
        
        broadcaster.eventListeners.Add(this);
        eventBroadcasters.Add(broadcaster);
        broadcaster.MBEvent += OnInvoke;
        broadcaster.EnableComp += EnableComponent;

    }

    public void Unsubscribe(EventHandler broadcaster)
    {
        //Manual
        //unsubscribe from listener side so broadcaster side wont have alot of stuff
        broadcaster.eventListeners.Remove(this);
        eventBroadcasters.Remove(broadcaster);
        broadcaster.MBEvent -= OnInvoke;
        broadcaster.EnableComp -= EnableComponent;


    }

    public virtual void OnInvoke(Trait ID,object data)
    { 
    }

    public virtual void OnGlobalEventInvoke(object data)
    {

    }

    public virtual void EnableComponent(Trait ID,bool enabled)
    {

    }


}

[Serializable]
public class StateBinder
{
    public Trait key;
    public State state;
}

public interface Idamageable
{

}
