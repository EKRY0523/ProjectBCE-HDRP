using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class EnemyStaticMovement : Movement
{
    NavMeshAgent agent;
    Coroutine DetectDecision;
    public int backOff;

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
        if (target != null)
        {
            if (DetectDecision != null)
            {
                StopCoroutine(DetectDecision);

            }
            DetectDecision = StartCoroutine(GetTarget());
            //agent.SetDestination(target.position);

        }
    }

    private void OnDisable()
    {
        if (DetectDecision != null)
        {
            StopCoroutine(DetectDecision);

        }
    }



    public void GoToTarget()
    {
        backOff = Random.Range(-5, 5);
        if(backOff > 0)
        {
            agent.SetDestination(target.position);

        }
        else
        {
            agent.SetDestination(-target.position);

        }
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

    public IEnumerator GetTarget()
    {
        while (true)
        {
            if (target != null)
            {
                GoToTarget();
            }
           
            yield return null;
        }
    }

}
