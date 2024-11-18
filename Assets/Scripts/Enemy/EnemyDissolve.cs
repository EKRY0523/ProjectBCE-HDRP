using UnityEngine;
using DG.Tweening;

public class EnemyDissolve : EventHandler
{
    public MeshRenderer[] affectedMesh;
    MaterialPropertyBlock propertyblock;
    public bool dissapear;
    public float dissolveTime;
    public float dissolveSpeed;
    public override void Awake()
    {
        base.Awake();
        propertyblock = new MaterialPropertyBlock();
        for (int i = 0; i < affectedMesh.Length; i++)
        {
            affectedMesh[i].SetPropertyBlock(propertyblock);
        }
    }

    private void OnEnable()
    {
        dissapear = true;
    }
    private void Update()
    {
        if(dissapear == true)
        {
            propertyblock.SetFloat("_DissolveAmount",dissolveTime+=(Time.deltaTime*dissolveSpeed));
            for (int i = 0; i < affectedMesh.Length; i++)
            {
                affectedMesh[i].SetPropertyBlock(propertyblock);
            }

            if (dissolveTime > 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
