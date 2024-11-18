using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;
public class StoryHandler : EventHandler
{
    public static StoryHandler Instance;
    public GameStoryData gameData;
    public UIControl uiControl;
    //public StoryProgress[] storyProgresses; // use this to turn colliders on and off
    public int StoryIndex;
    public int currentIndex;
    public GameObject[] UIOff;
    public Flowchart flow;
    public override void Awake()
    {
        Instance = this;
        base.Awake();
        flow = GetComponent<Flowchart>();
        
    }

    public void Start()
    {
        GameManager.instance.LoadGameData();
        gameData = GameManager.instance.gameData;
        MBEvent?.Invoke(null, gameData.currentStoryProgress);

    }
    public void StartStory()
    {
        uiControl.DisableInput();
        for (int i = 0; i < UIOff.Length; i++)
        {
            UIOff[i].gameObject.SetActive(false);
        }
    }

    public void EndStory()
    {
        uiControl.EnableInput();
        for (int i = 0; i < UIOff.Length; i++)
        {
            UIOff[i].gameObject.SetActive(true);
        }
        MBEvent?.Invoke(null, gameData.currentStoryProgress);
    }


}