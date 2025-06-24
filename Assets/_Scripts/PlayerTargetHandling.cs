using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerTargetHandling : TargetHandling
{
    public InputActionReference[] input;
    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < input.Length; i++)
        {
            input[i].action.performed += GetTarget;
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        for (int i = 0; i < input.Length; i++)
        {
            input[i].action.performed -= GetTarget;
        }
    }
    public void GetTarget(InputAction.CallbackContext ctx)
    {
        targets.Clear();
        CheckPlayertarget();
    }

    public void CheckPlayertarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerToHit);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (Physics.Linecast(transform.position, colliders[i].transform.position) == colliders[i].transform)
            {
                if (colliders[i].CompareTag(tagToHit))
                {
                    if (!targets.Contains(colliders[i].transform))
                    {
                        targets.Add(colliders[i].transform);
                    }
                }
            }
        }
        targets.RemoveAll(target => target == null);

        if (targets.Count > 0)
        {
            GetNearestTarget();
        }
        else
        {
            currentNearestTarget = null;
            MBEvent?.Invoke(null,null);
        }
    }

}
