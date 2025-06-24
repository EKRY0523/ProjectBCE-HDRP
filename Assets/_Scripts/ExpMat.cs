using UnityEngine;
using UnityEngine.Audio;
public class ExpMat : EventHandler
{
    public float exp;
    public Transform target;
    public AudioSource source;
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    private void Update()
    {
        if(target!=null)
        {
            transform.rotation = Quaternion.LookRotation(target.transform.position-transform.position);
            transform.Translate(Vector3.forward * 2f * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(("Player")))
        {
            if(other.GetComponent<PartyHandler>())
            {
                other.GetComponent<PartyHandler>().activeCharacter.ReceiveExp(exp);
                source.Play();
                Destroy(gameObject,1f);

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
