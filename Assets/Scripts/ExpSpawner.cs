using UnityEngine;

public class ExpSpawner : MonoBehaviour
{
    public ExpMat expMat;
    public ExpMat expOrb;
    public float exp;
    private void Start()
    {
        expOrb = Instantiate(expMat,transform);
        expOrb.exp = exp;
        expOrb.transform.position = this.transform.position;
        expOrb.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        expOrb.gameObject.SetActive(true);
        expOrb.transform.parent = null;
    }
}
