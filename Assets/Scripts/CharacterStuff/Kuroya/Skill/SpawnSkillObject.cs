using UnityEngine;

public class SpawnSkillObject : SkillObject
{
    public int count; //rate of object or instances of damage
    public SkillObject objectToSpawn;
    public override void Awake()
    {
        base.Awake();
        objectToSpawn.multiplier = (multiplier / count);

        for (int i = 0; i < count; i++)
        {
            Instantiate(objectToSpawn,transform.parent);
        }
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
