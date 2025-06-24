using UnityEngine;

public class ProgressStory : MonoBehaviour
{
    public int index;
    private void OnEnable()
    {
        StoryHandler.SetIndex(index);
    }
}
