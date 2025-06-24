using UnityEngine;

public class Detachself : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.parent = null;
        Destroy(gameObject,1.5f);
    }

}
