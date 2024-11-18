using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;
public class StoryHandler : EventHandler
{
    public UIControl uiControl;
    public int StoryIndex;
    public int currentIndex;
    public Flowchart[] flowchart;

    public override void Awake()
    {
        base.Awake();
    }

    public void StartStory(int index)
    {
        //global event call this
        uiControl.DisableInput();
    }

    public void EndStory()
    {
        uiControl.EnableInput();
    }

    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
        if(data is int)
        {

        }
    }
}
