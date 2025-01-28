using UnityEngine;
using TMPro;
using System;
public class ValueReceived : MonoBehaviour
{
    public TextMeshProUGUI dmgText;
    public float offset;
    public float maxY;
    private void Start()
    {
        Destroy(gameObject,1f);
        transform.position = transform.position + new Vector3(UnityEngine.Random.Range(-offset,offset), UnityEngine.Random.Range(1, maxY), UnityEngine.Random.Range(-offset, offset));
    }

    public void GetValue(float val)
    {
        dmgText.text = String.Format("{0:0}",Mathf.Abs(val));
    }
}
