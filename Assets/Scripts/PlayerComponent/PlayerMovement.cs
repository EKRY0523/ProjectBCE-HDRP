using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerMovement : Movement
{
    public enum StateTransitioning
    {
        inAttack,CanMove
    }

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

        if (input != null)
        {
            input.MovementInput += OnMove;
            walkSwitch.action.started += SwitchMode;
            moveMode = key[2];
            //speed = 5f;

        }


        //statemachine = GetComponentInChildren<Statemachine>();
    }

    private void Start()
    {
        

    }
    private void OnEnable()
    {
        

    }

    private void OnDisable()
    {
    }

    public override void OnMove(Vector2 Direction)
    {
        if(enableMovement)
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
            //speed = 5f;
        }
        else
        {
            moveMode = key[1];
            //speed = 2f;
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
        else if(data is MovementData)
        {
            movementData = (MovementData)data;
            movementData.MoveCharacter(rb);
        }

        if(ID == key[1] || ID == key[2])
        {
            if(data is int)
            {
                speed = 2f + (2 * (int)data);
            }
        }
        
        if(data is StateTransitioning)
        {
            if((StateTransitioning)data == StateTransitioning.inAttack)
            {
                enableMovement = false;
            }
            else
            {
                enableMovement = true;
            }
        }

        
    }


}
