using UnityEngine;
using System;
using System.Collections.Generic;

public class EventBroadcaster : MonoBehaviour
{
    public Action<EventBroadcaster,MonoBehaviour,object> eventToExecute;
    public Action<object> executableEvent;
    public CustomEvent customEvent;
    public List<EventSubscriber> subscribers = new List<EventSubscriber>();

    public virtual void OnEnable()
    {
        //customEvent?.Subscribe(this);

        if(subscribers.Count != 0)
        {
            for (int i = 0; i < subscribers.Count; i++)
            {
                executableEvent += subscribers[i].OnInvoke;
            }
        }
    }

    public virtual void OnDisable()
    {
        //customEvent?.Unsubscribe(this);
        if (subscribers.Count != 0)
        {
            for (int i = 0; i < subscribers.Count; i++)
            {
                executableEvent -= subscribers[i].OnInvoke;
            }
        }
    }

    //public virtual void EventToDo(EventBroadcaster listener,MonoBehaviour sender,object data)
    //{
    //    eventToExecute(listener,sender,data);
    //}
}
