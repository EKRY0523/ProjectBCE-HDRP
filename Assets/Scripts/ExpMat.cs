using UnityEngine;
using DG.Tweening;
public class ExpMat : MonoBehaviour
{
    public float exp;
    public bool goToTarget;
    public PartyHandler target;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.enabled = true;
            target = other.GetComponent<PartyHandler>();
            goToTarget = true;
        }
    }

    private void Update()
    {
        if(goToTarget && target!=null)
        {
            transform.position =Vector3.MoveTowards(transform.position, target.transform.position, 3f);
            if(Vector3.Distance(transform.position,target.transform.position) <1f)
            {
                target.activeCharacter.ReceiveExp(exp);
                Destroy(gameObject);
            }
        }
    }
}
