using UnityEngine;

public class CloseOnTrigger : MonoBehaviour
{
    public GameObject[] objToClose;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < objToClose.Length; i++)
        {
            objToClose[i].gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

}
