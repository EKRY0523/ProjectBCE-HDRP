using UnityEngine;
using System.Collections.Generic;

public class StoryCondition : EventHandler
{
    public enum StoryCompleteCondition
    {
        DestroyEnemy,ReachPosition
    }

    public List<GameObject> enemy = new();
    public GameObject activateBlock;
    public StoryCompleteCondition completeCondition;

    public override void Awake()
    {
        OnEnable();
    }

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        if(completeCondition == StoryCompleteCondition.DestroyEnemy)
        {
            if(enemy.Count ==0 )
            {
                MBEvent?.Invoke(null,false); //call startstory to close
                activateBlock.gameObject.SetActive(true);
            }
            else
            {
                for (int i = 0; i < enemy.Count; i++)
                {
                    if(enemy[i]==null)
                    {
                        enemy.RemoveAt(i);
                    }
                }
            }
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
