using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class EnemySpawner : EventHandler
{
    public Enemy[] enemyPrefab;
    public List<Enemy> EnemyList = new();
    public float spawnCooldown;
    public bool shouldSpawn;
    public Transform[] transformPoints;

    public int averageLevel;
    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void Update()
    {
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            if(averageLevel==0)
            {
                enemyPrefab[i].lv = 1;
            }
            else
            {
                enemyPrefab[i].lv = averageLevel;
            }
        }
    }

    public void GetAverageLevel()
    {
        float totalLevel = 0;
        for (int i = 0; i < GameManager.instance.UnlockedCharacters.Count; i++)
        {
            totalLevel += GameManager.instance.characterLoading[GameManager.instance.UnlockedCharacters[i].character.ID].lv;
        }

        averageLevel = (int)totalLevel / 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetAverageLevel();
        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i] == null)
            {
                EnemyList.RemoveAt(i);
            }
        }
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                EnemyList[i].gameObject.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i] == null)
            {
                EnemyList.RemoveAt(i);
            }
        }
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                EnemyList[i].gameObject.SetActive(false);
            }
        }
    }

        IEnumerator SpawnEnemy()
    { 
        while(true)
        {
            yield return new WaitForSeconds(spawnCooldown);
            for (int i = 0; i < EnemyList.Count; i++)
            {
                if(EnemyList[i]==null)
                {
                    EnemyList.RemoveAt(i);
                }
            }
            if (EnemyList.Count < 10)
            {
                Enemy enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], transformPoints[Random.Range(0, transformPoints.Length)]);
                EnemyList.Add(enemy);
            }
        }
        
    }
}
