using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerMovement : Movement
{
    //steps
    public LayerMask ignore;
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 2f;
    //
    public Trait[] key;
    public PlayableCharacterData character; 
    public Statemachine statemachine;
    public State state;
    public Transform camPos;
    public Vector2 MagnitudeTest;
    public PlayerInput input;
    public Trait moveMode;
    public InputActionReference walkSwitch;

    public bool enableMovement;

    public override void Awake()
    {
        base.Awake();
        moveMode = key[2];

    }

    private void OnEnable()
    {
        if (input != null)
        {
            input.MovementInput += OnMove;
            walkSwitch.action.started += SwitchMode;
        }

    }

    private void OnDisable()
    {
        magnitudeCheck = Vector2.zero;
        if (input != null)
        {
            input.MovementInput -= OnMove;
            walkSwitch.action.started -= SwitchMode;
        }
    }

    public override void OnMove(Vector2 Direction)
    {
        if (Direction.normalized.magnitude == 0f)
        {
            MBEvent?.Invoke(key[0], null);//Idle
        }
        else
        {
            MBEvent?.Invoke(moveMode, null);//walk
        }

        movementVector = camPos.forward * Direction.y + camPos.right * Direction.x;
        movementVector.y = 0;

        if (Direction.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(movementVector);
        }

        base.OnMove(Direction);
        
    }

    public override void Update()
    {
        base.Update();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void SwitchMode(InputAction.CallbackContext ctx)
    {
        if(moveMode == key[1])
        {
            moveMode = key[2];
            speed = 3f;
        }
        else
        {
            moveMode = key[1];
            speed = 1f;
        }
    }

    public override void OnInvoke(Trait ID,object data)
    {
        if(data is PlayableCharacterData)
        {
            if (statemachine != null)
            {
                statemachine?.Unsubscribe(this);
                Unsubscribe(statemachine);
            }
            
            character = (PlayableCharacterData)data;
            statemachine = character.statemachine;

            statemachine?.Subscribe(this);
            Subscribe(statemachine);

        }

        else if (data is MovementData)
        {
            movementData = data as MovementData;
            if (rb != null)
            {

                movementData.MoveCharacter(rb);
            }
            if (charController != null)
            {
                movementData.MoveCharacter(charController);
            }
        }

        //if(ID == key[1] || ID == key[2])
        //{
        //    if(data is int)
        //    {
        //        speed = 20f + (2 * (int)data);
        //    }
        //}

    }

    public override void EnableComponent(Trait ID, bool enabled)
    {
        base.EnableComponent(ID, enabled);
        if (ID == HandlerID)
        {
            this.enabled = enabled;
            //rb.linearVelocity = Vector3.zero;

        }
    }
    //void StepClimb()
    //{
    //    RaycastHit hitLower;
    //    if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f,~ignore))
    //    {
    //        RaycastHit hitUpper;
    //        if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f, ~ignore))
    //        {
    //            rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
    //        }
    //    }

    //    RaycastHit hitLower45;
    //    if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitLower45, 0.1f, ~ignore))
    //    {

    //        RaycastHit hitUpper45;
    //        if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitUpper45, 0.2f, ~ignore))
    //        {
    //            rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
    //        }
    //    }

    //    RaycastHit hitLowerMinus45;
    //    if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, 0.1f, ~ignore))
    //    {

    //        RaycastHit hitUpperMinus45;
    //        if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, 0.2f, ~ignore))
    //        {
    //            rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
    //        }
    //    }
    //}

}
