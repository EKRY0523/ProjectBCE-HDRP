using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour
{
    public int index;
    public GameObject flowchart;
    public StoryHandler handler;

    private void OnEnable()
    {
        StoryHandler.SetIndex(index);
        handler.StoryChecker(index);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flowchart.SetActive(true);
        }
    }
}
