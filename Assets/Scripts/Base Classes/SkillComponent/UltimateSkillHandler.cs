using UnityEngine;
using UnityEngine.InputSystem;
public class UltimateSkillHandler : SkillHandler
{
    public UltimateSkill ultimate;
    public override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        ultimate.OnSetup(character);
        cost = ultimate.cost;
        if (ultimate != null)
        {
            input.action.performed += OnExecute;
        }
    }

    private void OnDisable()
    {
        ultimate.OnRemove(character);
        if (ultimate != null)
        {
            input.action.performed -= OnExecute;
        }
    }
    public void OnChangeSkill(UltimateSkill newSkill)
    {
        ultimate.OnRemove(character);
        ultimate = newSkill;
        ultimate.OnSetup(character);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
    }
    public void OnExecute(InputAction.CallbackContext context)
    {
        if(canExecute)
        {
            if (cost != null)
            {
                if (character.statDictionary[cost.stat].statValue >= cost.cost)
                {
                    if (context.performed)
                    {
                        executionTime = Time.time;
                        canExecute = false;
                        ultimate.OnHold(ultimate.statAndMultiplier);
                        MBEvent?.Invoke(ultimate.key[0], null);
                        timeToExceed = ultimate.cooldown[0];
                        MBEvent?.Invoke(cost.stat, -cost.cost);

                        
                    }

                }

            }

        }
        
    }
    public override void Update()
    {
        base.Update();
    }

    public void SpawnUltimateSkillObject(int instance)
    {
        Instantiate(ultimate.skillInstance[0].skillObjects[instance], transform.parent);
    }

    public void SpawnDecoObject(GameObject obj)
    {
        Instantiate(obj, transform.parent);
    }
    public override void OnGlobalEventInvoke(object data)
    {
        base.OnGlobalEventInvoke(data);
    }
}
