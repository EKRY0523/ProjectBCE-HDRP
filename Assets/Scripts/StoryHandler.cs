using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class StoryHandler : EventHandler
{
    public enum StoryConditionType
    {
        defeat, reach, leveling
    }
    //public GameStoryData storyData;
    public UIControl uiControl;

    public int StoryIndex;
    public GameObject[] UIOff;
    public override void Awake()
    {
        base.Awake();
        
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    public void Start()
    {
        StoryIndex = GameManager.instance.storyProgress;

        if (StoryIndex == 8 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            StoryIndex = 9;
            GameManager.instance.storyProgress = 9;
        }


    }

    private void OnEnable()
    {
        if (StoryIndex == 8 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            StoryIndex = 9;
            GameManager.instance.storyProgress = 9;
        }
        Invoke(nameof(Delay), 1f);

    }


    public void Delay()
    {
        StoryChecker(StoryIndex);
    }
    public void StoryChecker(int index)
    {
        if (index == 0)
        {
            MBEvent?.Invoke(null, "Wake up");
            //tutorial
            if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1)
            {
                SceneManager.LoadScene(sceneBuildIndex: 1);
            }
        }
        else if (index == 1)
        {
            MBEvent?.Invoke(null, "Talk to Ren");

        }
        else if (index == 2)
        {
            MBEvent?.Invoke(null, "Go to Arcade");
        }
        else if (index == 3)
        {
            MBEvent?.Invoke(null, "Go to upper area shop");
        }
        else if (index == 4)
        {
            MBEvent?.Invoke(null, "Fight off NWO Agents"); // Ren gets unlocked
            //make it so that if ren isnt added, the collider to that area isnt opened
        }
        else if (index == 5)
        {
            MBEvent?.Invoke(null, "Talk to Edge"); //Edge gets unlocked
        }
        else if (index == 6)
        {
            MBEvent?.Invoke(null, "Go to abandoned spot");
        }
        else if (index == 7)
        {
            MBEvent?.Invoke(null, "One character reaches level 15");
        }
        else if (index == 8)
        {
            MBEvent?.Invoke(null, "Defeat Will of the Forgotten");
        }
        else
        {
            MBEvent?.Invoke(null, "To Be Continued");
        }
    }

    public static void SetIndex(int index)
    {
        if(index > GameManager.instance.storyProgress)
        {
            GameManager.instance.storyProgress = index;
        }

    }

    [Serializable]
    public class StoryCondition
    {
        public GameObject[] ThingsToSetActive;
        
    }

}