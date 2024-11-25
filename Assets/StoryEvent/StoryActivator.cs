using UnityEngine;
using System;
public class StoryActivator : EventHandler
{
    public int currentIndex;
    public IndexStoryBinder[] binder;

    private void Start()
    {
        for (int i = 0; i < binder.Length; i++)
        {
            if (GameManager.instance.storyProgress == binder[i].identifier)
            {
                binder[i].objectToActivate.gameObject.SetActive(true);
            }

        }
    }
}

[Serializable]
public class IndexStoryBinder
{
    public int identifier;
    public GameObject objectToActivate;
}
