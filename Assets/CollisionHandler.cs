using UnityEngine;

public class CollisionHandler : EventHandler
{
    public Collider parentCollider;
    public Collider collisionCollider;
    public GameObject hitIndication;
    public GameObject dami;
    private void Start()
    {
        parentCollider = GetComponent<Collider>();
        Physics.IgnoreCollision(parentCollider, collisionCollider,true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SkillObject") && tag == "Dodge")
        {
            if(hitIndication!=null && dami==null)
            {
                dami = (Instantiate(hitIndication, transform)); //indicate that hit is success
                dami.transform.position = transform.position;
            }
            MBEvent?.Invoke(HandlerID,true);
        }
    }


}
