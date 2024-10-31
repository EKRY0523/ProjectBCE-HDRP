using UnityEngine;
using UnityEngine.InputSystem;
public class RotateTowardsTarget : EventHandler
{
    public InputActionReference[] input;
    public Transform target;
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
            if(target!=null)
            {
                Vector3 lookAt = target.position - transform.position;
                lookAt.y = 0;
                transform.rotation = Quaternion.LookRotation(lookAt);
            }
        }
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Transform)
        {
            target = (Transform)data;
        }
    }
}
