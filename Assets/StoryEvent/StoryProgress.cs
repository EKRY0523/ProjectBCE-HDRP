using UnityEngine;

public class StoryProgress : EventHandler
{
    public int order;
    public bool completed;
    public GameStoryData gameData;
    public Player player;
    public override void Awake()
    {
        base.Awake();
    }

    public void CheckComplete(bool completed)
    {
        if(completed)
        {
            if(player!=null)
            {
                gameData.lastSavedPosition = player.transform.position;
                gameData.currentStoryProgress = order+1;
            }
            else
            {
                gameData.lastSavedPosition =GameManager.instance.gameData.lastSavedPosition;
                gameData.currentStoryProgress = order+1;
            }
            GameManager.instance.gameData = gameData;

            GameManager.instance.SaveGameData();
            StoryHandler.Instance.EndStory();
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is int)
        {
            if((int)data == order)
            {
                gameObject.SetActive(true);
                //StoryHandler.Instance.StartStory();
                MBEvent?.Invoke(null,null);
                Debug.Log(order);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        if(data is bool)
        {
            CheckComplete((bool)data);
        }
    }

}
