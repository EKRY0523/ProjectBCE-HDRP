using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class SkillHandler : EventHandler
{
    public Statemachine statemachine;
    public PlayableCharacterData character;

    public float stat;
    public InputActionReference input;
    public Coroutine cooldownHandler,ExitHandler;
    public float executionTime,timeToExceed; //To handle time.time stuff is running and to do cooldownChecks
    public bool canExecute;

    public override void Awake()
    {
        base.Awake();
        canExecute = true;
        character = GetComponent<PlayableCharacterData>();
        statemachine = GetComponent<Statemachine>();
    }
    public IEnumerator HandleCooldown(float seconds)
    {
        canExecute = false;
        yield return new WaitForSeconds(seconds);
        canExecute = true;
        StopCoroutine(cooldownHandler);
        cooldownHandler = null;
        
    }

    public virtual void Update()
    {
        if (Time.time >= executionTime + timeToExceed)
        {
            canExecute = true;
        }//handle CD properly
        if(Time.time > executionTime + timeToExceed + 1f)
        {
            Exit();
        }
    }

    public IEnumerator ExitSkill(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Exit();
        ExitHandler=null;

    }

    public void OnSkillSwitch()
    {
        executionTime = 0;
        canExecute = true;
    }

    public virtual void Exit()
    {

    }
}
