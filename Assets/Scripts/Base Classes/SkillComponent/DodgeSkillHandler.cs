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
    public bool held;
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
            if(!dodge.affectedByInput)
            {
                if (character.statDictionary[cost.stat].statValue >= cost.cost)
                {

                    if (context.performed)
                    {
                        held = true;
                        hit = false;
                        dodge.OnHold(dodge.statAndMultiplier);
                        MBEvent?.Invoke(dodge.key[0], null);
                        timeToExceed = dodge.cooldown[0];
                        MBEvent?.Invoke(cost.stat, -cost.cost);

                    }
                    if(held)
                    {
                        if (context.canceled)
                        {
                            held = false;
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
            }
            else
            {
                if (context.performed)
                {
                    canExecute = false;
                    executionTime = Time.time;
                    dodge.OnHold(dodge.statAndMultiplier);
                    MBEvent?.Invoke(dodge.key[0], null);
                    //statemachine.MBEvent?.Invoke(dodge.key[0], dodge.movementData[0]);

                }
                if (context.canceled)
                {
                    dodge.OnRelease(dodge.statAndMultiplier);
                    //MBEvent?.Invoke(dodge.key[0], null);
                    //statemachine.MBEvent?.Invoke(dodge.key[0], dodge.movementData[0]);
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

    public void MoveDodgeCharacter(MovementData movementData)
    {
        
        statemachine.MBEvent?.Invoke(null, movementData);

    }

    public void SpawnDodgeSkillObject(int instance)
    {
        //Debug.Log((dodge.skillInstance[0].skillObjects[instance].multiplier));
        Instantiate(dodge.skillInstance[0].skillObjects[instance], transform.parent);

    }

    public void SpawnBlink(GameObject vfx)
    {
       Destroy(Instantiate(vfx, transform.parent),0.7f);
    }

    public void SetInvul()
    {
        transform.parent.tag = "Dodge";
        Debug.Log(transform.parent.tag);
    }

    public void UnSetInvul()
    {
        transform.parent.tag = "Player";
        Debug.Log(transform.parent.tag);
    }

    public void Direction(Vector2 direction)
    {
        if(direction.magnitude!=0)
        {
            facingDirection.x = direction.x;
            facingDirection.z = direction.y;

        }
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
