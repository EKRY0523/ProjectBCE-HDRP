using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class Movement : EventHandler
{
    protected Vector2 magnitudeCheck;
    protected Vector3 movementVector;
    [SerializeField] protected MovementComponent movementComponent;
    protected Rigidbody rb;
    [SerializeField] protected float speed;
    public MovementData movementData;

    public override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    public virtual void OnMove(Vector2 Direction)
    {
        magnitudeCheck = Direction;
        movementComponent.MoveCharacter(rb, movementVector * speed);
    }

    public virtual void FixedUpdate()
    {
        if (magnitudeCheck.magnitude != 0)
        {
            OnMove(magnitudeCheck);
        }
    }


    public override void OnInvoke(Trait ID,object data)
    {
        if(data is MovementData)
        {
            movementData = data as MovementData;
            movementData.MoveCharacter(rb);
        }
    }
}
