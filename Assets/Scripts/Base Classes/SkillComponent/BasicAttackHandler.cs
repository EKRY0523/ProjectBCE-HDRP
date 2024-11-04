using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class BasicAttackHandler : SkillHandler
{
    public CharacterBasicAttack basicAttack;
    public int count;
    public bool firstInput = true;
    public float enterTime,maxTime;
    public int numTesting;

    public override void Awake()
    {
        base.Awake();
        canExecute = true;
    }
    public void OnEnable()
    {
        //base.OnEnable();
        basicAttack.OnSetup(character);
        if (basicAttack != null)
        {
            input.action.performed += OnExecute;
            input.action.canceled += OnExecute;
        }

        timeToExceed = basicAttack.cooldown[count];
    }

    public void OnDisable()
    {
        //base.OnDisable();
        basicAttack.OnRemove(character);
        if (basicAttack != null)
        {
            input.action.performed -= OnExecute;
            input.action.canceled -= OnExecute;
        }
    }


    public void OnExecute(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(canExecute)
            {
                executionTime = Time.time;
                canExecute = false;
                if (firstInput)
                {
                    count = 0;
                    firstInput = false;
                }
                else
                {

                    if (count < basicAttack.MaxCount)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                basicAttack.AttackCount(count, basicAttack.statAndMultiplier);
                MBEvent?.Invoke(basicAttack.key[count], null);
                statemachine.MBEvent?.Invoke(basicAttack.key[count], basicAttack.movementData[count]);

                timeToExceed = basicAttack.cooldown[count];
            }
        }

        
    }

    public override void Update()
    {
        base.Update();
        
    }
    public void OnChangeSkill(CharacterBasicAttack newBasicAttack)
    {
        basicAttack.OnRemove(character);
        basicAttack = newBasicAttack;
        basicAttack.OnSetup(character);
    }

    public override void Exit()
    {
        base.Exit();
        count = 0;
        firstInput = true;
    }

    public void SpawnSkillObject(int numTesting)
    {
        Debug.Log("Count"+count);
        Debug.Log("numtesting" + numTesting);

        Debug.Log((basicAttack.skillInstance[count].skillObjects[numTesting].multiplier));
        Instantiate(basicAttack.skillInstance[count].skillObjects[numTesting],transform.parent);
    }
}
