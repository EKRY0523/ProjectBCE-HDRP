using UnityEngine;
using System.Collections;
public class DelayedSpawnObject : SkillObject
{
    public SkillObject objToSpawn;
    public Coroutine spawnDelay;
    public float extraMultiplier;
    private void OnEnable()
    {
        this.tag = "SkillObject";
        objToSpawn.multiplier = multiplier * extraMultiplier;
        spawnDelay = StartCoroutine(SpawnObject());
        Destroy(gameObject, duration);
        if (detachFromParent)
        {
            transform.parent = null;
        }

    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(duration - 0.2f);
        objToSpawn.detachFromParent = true;
        Instantiate(objToSpawn,transform);
        StopCoroutine(spawnDelay);
    }
}
