using UnityEngine;

public class CollisionHandler : EventHandler
{
    public Collider parentCollider;
    public Collider collisionCollider;

    private void Start()
    {
        parentCollider = GetComponent<Collider>();
        Physics.IgnoreCollision(parentCollider, collisionCollider,true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SkillObject") && tag == "Dodge")
        {
            MBEvent?.Invoke(HandlerID,true);
        }
    }


}
