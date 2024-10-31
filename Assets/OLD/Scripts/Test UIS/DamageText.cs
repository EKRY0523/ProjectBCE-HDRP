using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(2*transform.position - Camera.main.transform.position);
        Destroy(this.gameObject, 0.3f);
        transform.position = new Vector3(Random.Range(transform.position.x-2f, transform.position.x+2f), Random.Range(transform.position.y, transform.position.y+ 2f), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
        
    }

    public void setText()
    {
        
    }
}
