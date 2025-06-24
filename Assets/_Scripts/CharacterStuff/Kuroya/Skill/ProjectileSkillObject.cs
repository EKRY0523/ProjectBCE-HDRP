using UnityEngine;
using DG.Tweening;

public class ProjectileSkillObject : SkillObject
{
    public Vector3 offset;
    public Vector3 lookPos;
    public float speed;
    public bool StopGetTarget;
    public Vector3 markedPos;
    public override void Awake()
    {
        base.Awake();
        //transform.parent = null;
        transform.position = transform.position + offset + new Vector3(Random.Range(-5,5),0, Random.Range(-5, 5));
    }

    private void Start()
    {
        if(target==null)
        {

            transform.rotation = Quaternion.LookRotation(transform.forward - transform.up);
        }
        else
        {

            lookPos = target.transform.position - transform.position;
            markedPos = target.transform.position;
        }
    }
    private void Update()
    {
        if(target!=null)
        {
            if(StopGetTarget)
            {
                transform.rotation = Quaternion.LookRotation(lookPos);
                transform.DOMove(markedPos, speed);
            }
            else
            {
                lookPos = target.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(lookPos);
                transform.DOMove(target.transform.position, speed);
            }
        }
        else
        {
            transform.DOLocalMove(transform.forward, speed);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.CompareTag(tagName))
        {
            Destroy(gameObject,0.4f);
        }
    }
}
