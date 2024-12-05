using UnityEngine;
using UnityEngine.Audio;
public class BGMOnTrigger : EventHandler
{
    public AudioClip clippy;
    public override void Awake()
    {
        base.Awake();

    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            MBEvent?.Invoke(null, clippy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MBEvent?.Invoke(null, null);
        }
    }
}
