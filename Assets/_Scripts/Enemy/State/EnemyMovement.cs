using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class EnemyMovement : Movement
{
    NavMeshAgent agent;
    Coroutine DetectDecision;
    public Transform target;
    public Transform[] waypoint;
    public Trait[] key;
    public float stoppingRange;
    int index;
    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        if(target!=null)
        {
            if (DetectDecision != null)
            {
                StopCoroutine(DetectDecision);

            }
            DetectDecision = StartCoroutine(GetTarget());
            //agent.SetDestination(target.position);

        }
        else
        {
            if(waypoint.Length>0)
            {
                agent.SetDestination(waypoint[index].transform.position);
                if (DetectDecision != null)
                {
                    StopCoroutine(DetectDecision);

                }
                DetectDecision = StartCoroutine(GetTarget());
            }
            
        }
    }

    private void OnDisable()
    {
        if (DetectDecision != null)
        {
            StopCoroutine(DetectDecision);

        }
    }

    public void WaypointTraversal()
    {
        if (index >= waypoint.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        if(DetectDecision!=null)
        {
            StopCoroutine(DetectDecision);

        }
        

    }

    public void GoToTarget()
    {
        agent.SetDestination(target.position);
        MBEvent?.Invoke(key[3], null); //Chasing
        Vector3 lookAt = target.position - transform.position;
        lookAt.y = 0;
        transform.rotation = Quaternion.LookRotation(lookAt);
    }

    public override void OnInvoke(Trait ID, object data)
    {
        base.OnInvoke(ID, data);
        if(data is Transform)
        {
            target = (Transform)data;
            if (target!=null)
            {
                MBEvent?.Invoke(key[4], null); //detected
                Vector3 lookAt = target.position - transform.position;
                lookAt.y = 0;
                transform.rotation = Quaternion.LookRotation(lookAt);
            }
        }
       
    }

    public IEnumerator GetTarget()
    {
        while (true)
        {
            if (target != null)
            {
                GoToTarget();
            }
            else
            {

                if (Vector3.Distance(transform.position, waypoint[index].position) <= agent.stoppingDistance)
                {
                    MBEvent?.Invoke(key[0], null); //Idle

                    WaypointTraversal();
                }
                else
                {
                    MBEvent?.Invoke(key[1], null); //Moving
                }
            }
            yield return null;
        }
    }

}
