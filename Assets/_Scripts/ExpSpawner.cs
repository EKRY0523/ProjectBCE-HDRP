using UnityEngine;
using System;
public class ExpSpawner : MonoBehaviour
{
    public ExpMat expMat;
    public ExpMat expOrb;
    public float exp;
    private void Start()
    {
        expOrb = Instantiate(expMat,transform);
        expOrb.exp = exp * 1.5f* GetComponent<Enemy>().lv;
        expOrb.transform.position = this.transform.position;
        expOrb.gameObject.SetActive(false);
        expOrb.transform.parent = null;
    }
    private void OnDestroy()
    {
        if(expOrb!=null)
        {

            expOrb.transform.position = this.transform.position + new Vector3(0,1,0);
            expOrb.gameObject.SetActive(true);
        }
    }
}
