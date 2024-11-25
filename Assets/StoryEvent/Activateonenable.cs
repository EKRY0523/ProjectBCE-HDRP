using UnityEngine;

public class Activateonenable : MonoBehaviour
{
    public int index;
    public GameObject flowchartActivation;
    public StoryHandler handler;
    private void Start()
    {
        StoryHandler.SetIndex(index);
        handler.StoryChecker(index);
        flowchartActivation.SetActive(true);
    }
}
