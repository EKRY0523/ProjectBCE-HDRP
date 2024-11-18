using UnityEngine;

public class StartStory : EventHandler
{
    public StoryProgress story;

    public override void Awake()
    {
        base.Awake();
    }

    private void OnDisable()
    {
        if (StoryHandler.Instance != null)
        {
            story.CheckComplete(true);
        }

    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is bool)
        {
            gameObject.SetActive((bool)data);
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
