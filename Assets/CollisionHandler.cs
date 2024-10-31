using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Collider parentCollider;
    public Collider collisionCollider;

    private void Start()
    {
        parentCollider = GetComponent<Collider>();
        Physics.IgnoreCollision(parentCollider, collisionCollider,true);
    }
}
