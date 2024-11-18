using UnityEngine;
using System.Collections.Generic;
public class TargetHandling : EventHandler
{
    public List<Transform> targets = new();
    public Transform currentNearestTarget;
    public float radius;
    public LayerMask layerToHit;
    public string tagToHit;
    public RaycastHit hit;
    public bool canGet;
    public override void Awake()
    {
        base.Awake();
    }

    private void FixedUpdate()
    {
        CheckTargetsValidity();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    public void CheckTargetsValidity()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius,layerToHit);
        for (int i = 0; i < colliders.Length; i++)
        {
            if(Physics.Linecast(transform.position, colliders[i].transform.position) == colliders[i].transform)
            {
                if(colliders[i].CompareTag(tagToHit))
                {
                    if (!targets.Contains(colliders[i].transform.parent))
                    {
                        targets.Add(colliders[i].transform.parent);
                    }
                }
            }
        }
        if (targets.Count > 0)
        {
            GetNearestTarget();
        }
    }
    public void GetNearestTarget()
    {

        for (int i = 0; i < targets.Count; i++)
        {
            if(targets[i]==null)
            {
                targets.RemoveAt(i);
            }
            if (currentNearestTarget == null)
            {
                if(targets.Count>0)
                {

                    currentNearestTarget = targets[i];
                }
            }
            else
            {
                if(Vector3.Distance(transform.position, currentNearestTarget.position) > Vector3.Distance(transform.position, targets[i].position))
                {
                    currentNearestTarget = targets[i];
                }
            }
        }
        if(currentNearestTarget!=null)
        {

            MBEvent?.Invoke(null, currentNearestTarget);
        }
        //targets.Clear();
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is float)
        {
            if((float)data == 50f)
            {
                radius = (float)data;
            }
        }
    }
}
