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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SkillObject") && gameObject.CompareTag("Enemy"))
        {
            radius = 50f;
        }
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
        }
    }
    public void GetNearestTarget()
    {

        for (int i = 0; i < targets.Count; i++)
        {
            if(currentNearestTarget==null && targets.Count>0)
            {
                currentNearestTarget = targets[i];
            }
            else
            {

            }
        }

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
                if(targets[i]!=null)
                {

                    if (Vector3.Distance(transform.position, currentNearestTarget.position) > Vector3.Distance(transform.position, targets[i].position))
                    {
                        currentNearestTarget = targets[i];
                    }
                }
            }
        }
        if(currentNearestTarget!=null)
        {

            MBEvent?.Invoke(null, currentNearestTarget);
        }
        else
        {
            MBEvent?.Invoke(null, null);
        }
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
