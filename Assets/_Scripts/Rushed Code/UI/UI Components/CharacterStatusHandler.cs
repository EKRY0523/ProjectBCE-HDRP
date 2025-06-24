using UnityEngine;

public class CharacterStatusHandler : EventHandler
{
    public Entity entity;
    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        MBEvent?.Invoke(null,entity);
    }
    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);

        if (data is float)
        {
            MBEvent.Invoke(ID, (float)data);
        }

        if (data is Entity)
        {
            MBEvent?.Invoke(null, (Entity)data);
            if (entity != null)
            {
                Unsubscribe(entity);
            }
            entity = (Entity)data;
            Subscribe(entity);
        }
    }

    //public override void OnGlobalEventInvoke(object data)
    //{
    //    base.OnGlobalEventInvoke(data);
    //    if(data is Entity)
    //    {
    //        MBEvent?.Invoke(null,(Entity)data);
    //        if (entity != null)
    //        {
    //            Unsubscribe(entity.statHandler);
    //        }
    //        entity = (Entity)data;
    //        Subscribe(entity.statHandler);
    //    }

        
        
    //}

    //public void EnableCharacterInstantly(PlayableCharacterData data)
    //{
    //    entity = (Entity)data;
    //    MBEvent?.Invoke(null,(Entity)data);
    //    Subscribe(entity.statHandler);
    //}
}
