using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class Movement : EventHandler
{
    //testing
    public CharacterController charController;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    //

    protected Vector2 magnitudeCheck;
    protected Vector3 movementVector;
    [SerializeField] protected MovementComponent movementComponent;
    protected Rigidbody rb;
    [SerializeField] protected float speed;
    public MovementData movementData;

    public bool grounded;
    public override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    public virtual void OnMove(Vector2 Direction)
    {
        magnitudeCheck = Direction;

        //movementComponent.MoveCharacter(rb, (movementVector * speed));

        //test
        movementComponent.MoveCharacter(charController,movementVector,speed);
            //

    }

    public virtual void Update()
    {
        if(charController!=null)
        {
            grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (!grounded)
            {
                charController.Move(Vector3.down * 9.81f * Time.deltaTime);
            }
            if (magnitudeCheck.magnitude != 0)
            {
                OnMove(magnitudeCheck);
            }

        }

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
            if(rb!=null)
            {

                movementData.MoveCharacter(rb);
            }
            if(charController!=null)
            {
                movementData.MoveCharacter(charController);
            }
        }
    }

    public override void EnableComponent(Trait ID, bool enabled)
    {
        base.EnableComponent(ID, enabled);
    }
}
