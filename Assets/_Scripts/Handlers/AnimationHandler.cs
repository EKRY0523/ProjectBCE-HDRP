using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AnimationHandler : EventHandler
{
    Animator animator;
    public string stateName;
    Coroutine dam;
    public float incrementedValue;
    public int oldFloat;
    public int placeholder;
    public PlayerInput input;



    public override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }



    public override void OnInvoke(Trait ID,object data)
    {
        if(data is int)
        {
            animator.SetInteger(stateName, (int)data);
            animator.SetFloat(stateName, (int)data);
        }
        else if(data is float)
        {
            //animator.SetFloat(stateName,(float)data);
            oldFloat = (int)animator.GetFloat(stateName);
            if(dam ==null)
            {

                dam = StartCoroutine(HandleBlending((float)data));
            }
        }
        else if(data is string)
        {
            stateName = (string)data;
            animator.SetTrigger((string)data);
        }
        else if(data is bool)
        {
            animator.SetBool(stateName, (bool)data);
        }
    }

    public IEnumerator HandleBlending(float NewValue)
    {
        incrementedValue = 0;
        placeholder = (int)NewValue;
        animator.SetFloat(stateName, oldFloat);

        while (animator.GetFloat(stateName)!=NewValue)
        {
            yield return null;
            incrementedValue += (3f * animator.GetCurrentAnimatorClipInfo(0).Length * Time.deltaTime);
            animator.SetFloat(stateName, Mathf.Lerp(oldFloat, NewValue, incrementedValue));

        }


        if (dam!=null)
        {
            StopCoroutine(dam);
            dam = null;
        }
    }
}
