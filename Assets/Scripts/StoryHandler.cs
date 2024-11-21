using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;
public class StoryHandler : EventHandler
{
    public static StoryHandler Instance;
    public GameStoryData gameData;
    public UIControl uiControl;

    //use this to check for stuff only

    public int StoryIndex;
    public int currentIndex;
    public GameObject[] UIOff;
    public Flowchart flow;
    public override void Awake()
    {
        Instance = this;
        base.Awake();
        
    }

    public void Start()
    {
        //GameManager.instance.LoadGameData();
        gameData = GameManager.instance.gameData;
        MBEvent?.Invoke(null, gameData.currentStoryProgress);
        //all subscribe to this initially
    }


}