using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : Movement
{
    NavMeshAgent agent;
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
            agent.SetDestination(target.position);
            //MBEvent?.Invoke(key[1], null); //Moving
        }
        else
        {
            agent.SetDestination(waypoint[index].transform.position);
            //WaypointTraversal();
        }
    }

    private void OnDisable()
    {
        //WaypointTraversal();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (target != null)
        {
            GoToTarget();
        }
        else
        {
            if (Vector3.Distance(transform.position, waypoint[index].position) < 1)
            {
                MBEvent?.Invoke(key[0], null); //Idle
                WaypointTraversal();
            }
            else
            {
                MBEvent?.Invoke(key[1], null); //Moving
            }
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
        
        

    }

    public void GoToTarget()
    {
        agent.SetDestination(target.position);
        MBEvent?.Invoke(key[3], null); //Chasing
        //if (Vector3.Distance(transform.position, target.position) < stoppingRange)
        //{
        //    MBEvent?.Invoke(key[2],null);//attacking
        //}
        //else
        //{
            
        //}
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
            }
        }
    }

}
