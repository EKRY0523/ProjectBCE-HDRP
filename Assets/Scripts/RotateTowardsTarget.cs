using UnityEngine;
using UnityEngine.InputSystem;
public class RotateTowardsTarget : EventHandler
{
    public InputActionReference[] input;
    public Transform target;
    public bool canRotate;

    public BasicAttackHandler attackHandler;
    public FirstSkillHandler firstSkillHandler;
    public SecondSkillHandler secondSkillHandler;
    public DodgeSkillHandler dodgeSkillHandler;
    public UltimateSkillHandler ultimateSkillHandler;
    public override void Awake()
    {
        base.Awake();
        

    }

    private void OnEnable()
    {
        for (int i = 0; i < input.Length; i++)
        {
            input[i].action.performed += RotateTowards;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < input.Length; i++)
        {
            input[i].action.performed -= RotateTowards;
        }
    }

    public void RotateTowards(InputAction.CallbackContext ctx)
    {   
        if(ctx.performed)
        {
            if(canRotate)
            {
                if (target != null)
                {
                    Vector3 lookAt = target.position - transform.position;
                    lookAt.y = 0;
                    transform.rotation = Quaternion.LookRotation(lookAt);
                }
            }
            
        }
    }
    public void RotateToTarget()
    {
        if(target!=null)
        {
            Vector3 lookAt = target.position - transform.position;
            lookAt.y = 0;
            transform.parent.rotation = Quaternion.LookRotation(lookAt);
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is null)
        {
            target = null;
        }
        if(data is Transform)
        {
            target = (Transform)data;
        }
        if(data is PlayableCharacterData)
        {
            PlayableCharacterData characterData = (PlayableCharacterData)data;
            if (attackHandler!=null)
            {
                Unsubscribe(attackHandler);
            }
            if (firstSkillHandler != null)
            {
                Unsubscribe(firstSkillHandler);
            }
            if (secondSkillHandler != null)
            {
                Unsubscribe(secondSkillHandler);
            }
            if (dodgeSkillHandler != null)
            {
                Unsubscribe(dodgeSkillHandler);
            }
            if (ultimateSkillHandler != null)
            {
                Unsubscribe(ultimateSkillHandler);
            }

            attackHandler = characterData.basic;
            firstSkillHandler = characterData.firstSkill;
            secondSkillHandler = characterData.secondSkill;
            dodgeSkillHandler = characterData.dodgeSkill;
            ultimateSkillHandler = characterData.ultimateSkill;
            Subscribe(attackHandler);
            Subscribe(firstSkillHandler);
            Subscribe(secondSkillHandler);
            Subscribe(dodgeSkillHandler);
            Subscribe(ultimateSkillHandler);
        }

        if(data is bool)
        {
            canRotate = (bool)data;
        }
    }
}
