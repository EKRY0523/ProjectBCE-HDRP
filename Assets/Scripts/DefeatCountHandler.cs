using UnityEngine;
using System.Collections.Generic;
public class DefeatCountHandler : EventHandler
{
    public int index;
    public List<GameObject> enemies = new();
    public GameObject flowchartActivation;
    public StoryHandler handler;
    private void Start()
    {
        //for (int i = 0; i < enemies.Count; i++)
        //{
        //    enemies[i].gameObject.SetActive(true);
        //}
    }

    private void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i]==null)
            {
                enemies.RemoveAt(i);
            }
        }

        if(enemies.Count<1)
        {
            flowchartActivation.SetActive(true);
            StoryHandler.SetIndex(index);
            if(handler!=null)
            {
                handler.StoryChecker(index);
                GameManager.instance.SaveGame();
            }
            Destroy(gameObject);
        }
    }
}
