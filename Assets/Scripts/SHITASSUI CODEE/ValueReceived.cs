using UnityEngine;
using TMPro;
public class ValueReceived : MonoBehaviour
{
    public TextMeshProUGUI dmgText;
    public float offset;
    private void Start()
    {
        Destroy(gameObject,1f);
        transform.position = transform.position + new Vector3(Random.Range(-offset,offset), Random.Range(1, 5), Random.Range(-offset, offset));
    }

    public void GetValue(float val)
    {
        dmgText.text = val.ToString();
    }
}
