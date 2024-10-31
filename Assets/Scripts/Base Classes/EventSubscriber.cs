using UnityEngine;

public abstract class EventSubscriber : MonoBehaviour
{
    public EventBroadcaster[] broadcaster;
    public void Subscribe()
    {
        for (int i = 0; i < broadcaster.Length; i++)
        {
            broadcaster[i].executableEvent += OnInvoke;
            broadcaster[i].subscribers.Add(this);
        }
    }
    public void Unsubscribe()
    {
        for (int i = 0; i < broadcaster.Length; i++)
        {
            broadcaster[i].executableEvent -= OnInvoke;
            broadcaster[i].subscribers.Remove(this);
        }
    }

    public void TargetedSubscription(EventBroadcaster broadcaster)
    {
        broadcaster.executableEvent += OnInvoke;
        broadcaster.subscribers.Add(this);
    }

    public void TargetedUnsubscription(EventBroadcaster broadcaster)
    {

        broadcaster.executableEvent -= OnInvoke;
        broadcaster.subscribers.Remove(this);
    }
    public abstract void OnInvoke(object data);
}
