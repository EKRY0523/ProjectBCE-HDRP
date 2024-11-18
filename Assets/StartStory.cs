using UnityEngine;

public class StartStory : EventHandler
{
    private void OnEnable()
    {
        if(StoryHandler.Instance!=null)
        {

            StoryHandler.Instance.StartStory();
        }
    }

    private void OnDisable()
    {
        if (StoryHandler.Instance != null)
        {

            StoryHandler.Instance.EndStory();
        }

    }
}
