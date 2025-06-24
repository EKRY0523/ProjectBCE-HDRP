using UnityEngine;

public class PairEnable : MonoBehaviour
{
    public GameObject pairOBJ;

    private void OnEnable()
    {
        pairOBJ.SetActive(true);
    }

    private void OnDisable()
    {
        pairOBJ?.SetActive(false);
    }
}
