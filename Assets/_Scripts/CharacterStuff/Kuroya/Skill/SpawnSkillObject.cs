using UnityEngine;

public class SpawnSkillObject : SkillObject
{
    public int count; //rate of object or instances of damage
    public SkillObject objectToSpawn;
    public float delay;
    public override void Awake()
    {
        base.Awake();
        objectToSpawn.multiplier = (multiplier / count);

        for (int i = 0; i < count; i++)
        {
            Invoke(nameof(DelaySpawn), i*delay);
            //Instantiate(objectToSpawn,transform.parent);
        }
    }

    public void DelaySpawn()
    {
        Instantiate(objectToSpawn, transform.parent);
    }
    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Transform)
        {
            target = (Transform)data;
            objectToSpawn.target = target;
        }
    }
}
