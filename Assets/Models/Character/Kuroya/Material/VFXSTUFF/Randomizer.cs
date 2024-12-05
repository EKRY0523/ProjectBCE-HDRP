using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject[] objects;
    private void Start()
    {
        objects[Random.Range(0,objects.Length)].SetActive(true);
    }
}
