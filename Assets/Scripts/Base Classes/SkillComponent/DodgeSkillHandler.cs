using UnityEngine;
using UnityEngine.InputSystem;
public class DodgeSkillHandler : SkillHandler
{
    public PlayerInput directionMultiplier;
    public Vector3 facingDirection;
    public DodgeSkill dodge;
    public Trait indicator;
    public CollisionHandler collisionHandler;
    public bool hit;
    public override void Awake()
    {
        base.Awake();
        collisionHandler = GetComponentInParent<CollisionHandler>();
    }
    private void OnEnable()
    {
        dodge.OnSetup(character);
        if(dodge.cost.stat!=null)
        {

            cost = dodge.cost;
        }
        if (dodge != null)
        {
            input.action.performed += OnExecute; 
            input.action.canceled += OnExecute;
        }
        if(directionMultiplier != null)
        {
            directionMultiplier.MovementInput += Direction;
        }
        Subscribe(collisionHandler);

      
    }

    private void OnDisable()
    {
        dodge.OnRemove(character);
        if (dodge != null)
        {
            input.action.performed -= OnExecute;
            input.action.canceled -= OnExecute;
        }
        if (directionMultiplier != null)
        {
            directionMultiplier.MovementInput -= Direction;
        }
        Unsubscribe(collisionHandler);
    }
    public void OnChangeSkill(DodgeSkill newSkill)
    {
        dodge.OnRemove(character);
        dodge = newSkill;
        dodge.OnSetup(character);
    }

    public void OnExecute(InputAction.CallbackContext context)
    {
        if (canExecute)
        {
            if(cost!=null)
            {
                if (character.statDictionary[cost.stat].statValue >= cost.cost)
                {

                    if (context.performed)
                    {
                        hit = false;
                        dodge.OnHold(dodge.statAndMultiplier);
                        MBEvent?.Invoke(dodge.key[0], null);
                        timeToExceed = dodge.cooldown[0];
                        //statemachine.MBEvent?.Invoke(dodge.key[0], dodge.movementData[0]);
                        MBEvent?.Invoke(cost.stat, -cost.cost);

                    }
                    if (context.canceled)
                    {
                        executionTime = Time.time;
                        canExecute = false;
                        dodge.OnRelease(dodge.statAndMultiplier);
                        dodge.OnHit(this);
                        MBEvent?.Invoke(indicator, null);
                        hit = false;
                        //statemachine.MBEvent?.Invoke(indicator, dodge.movementData[0]);
                    }
                }
            }
            else
            {
                if (context.performed)
                {
                    dodge.OnHold(dodge.statAndMultiplier);
                    MBEvent?.Invoke(dodge.key[0], null);
                    statemachine.MBEvent?.Invoke(dodge.key[0], dodge.movementData[0]);

                }
                if (context.canceled)
                {
                    dodge.OnRelease(dodge.statAndMultiplier);
                    MBEvent?.Invoke(dodge.key[0], null);
                    statemachine.MBEvent?.Invoke(dodge.key[0], dodge.movementData[0]);
                }
            }
            
        }

    }
    public void OnChangeSkill(CharacterSkill characterSkill)
    {
        dodge.OnRemove(character);
        dodge = (DodgeSkill)characterSkill;
        dodge.OnSetup(character);
    }

    public void MoveCharacter(MovementData movementData)
    {
        if(dodge.affectedByInput)
        {
            movementData.targetPosition.x = movementData.targetPosition.x * facingDirection.x;
            movementData.targetPosition.z = movementData.targetPosition.z * facingDirection.z;
        }
        statemachine.MBEvent?.Invoke(null, movementData);

    }

    public void SpawnDodgeSkillObject(int instance)
    {
        Debug.Log((dodge.skillInstance[0].skillObjects[instance].multiplier));
        Instantiate(dodge.skillInstance[0].skillObjects[instance], transform.parent);

    }

    public void Direction(Vector2 direction)
    {
        facingDirection.x = direction.x;
        facingDirection.z = direction.y;
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(ID == ComponentsID[0])
        {
            hit = true;
            dodge.OnHit(this);
        }
    }
}
