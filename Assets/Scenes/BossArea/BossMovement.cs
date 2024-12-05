using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class BossMovement : Movement
{
    NavMeshAgent agent;

    public Transform target;
    public Trait[] key;
    public float stoppingRange;
    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        agent.isStopped = false;
        if (target != null)
        {

            agent.SetDestination(target.position);
        }

        //if (target != null)
        //{
        //    if (DetectDecision != null)
        //    {
        //        StopCoroutine(DetectDecision);

        //    }
        //    //agent.SetDestination(target.position);

        //}
    }

    private void OnDisable()
    {
        agent.isStopped = true;
    }



    public void GoToTarget()
    {
        MBEvent?.Invoke(key[0], null); //Chasing
        Vector3 lookAt = target.position - transform.position;
        lookAt.y = 0;
        transform.rotation = Quaternion.LookRotation(lookAt);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if (data is Transform)
        {
            target = (Transform)data;
            if (target != null)
            {
                MBEvent?.Invoke(key[0], null); //detected
                Vector3 lookAt = target.position - transform.position;
                lookAt.y = 0;
                transform.rotation = Quaternion.LookRotation(lookAt);
            }
        }
        if (data is MovementData)
        {
            movementData = (MovementData)data;
            movementData.MoveCharacter(rb);
        }
    }


}
