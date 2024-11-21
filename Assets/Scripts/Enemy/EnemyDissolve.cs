using UnityEngine;
using DG.Tweening;

public class EnemyDissolve : EventHandler
{
    public MeshRenderer[] affectedMesh;
    public SkinnedMeshRenderer[] affectedSkins;
    MaterialPropertyBlock propertyblock;
    public bool dissapear;
    public float dissolveTime;
    public float dissolveSpeed;
    public bool reverse;
    public override void Awake()
    {
        base.Awake();
        propertyblock = new MaterialPropertyBlock();
        for (int i = 0; i < affectedMesh.Length; i++)
        {
            affectedMesh[i].SetPropertyBlock(propertyblock);
        }
        for (int i = 0; i < affectedSkins.Length; i++)
        {
            affectedSkins[i].SetPropertyBlock(propertyblock);
        }

        if(reverse)
        {
            dissolveTime = 1;
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
            if(!reverse)
            {
                propertyblock.SetFloat("_DissolveAmount", dissolveTime += (Time.deltaTime * dissolveSpeed));
            }
            else
            {
                propertyblock.SetFloat("_Thickness", dissolveTime -= (Time.deltaTime * dissolveSpeed));
            }
            for (int i = 0; i < affectedMesh.Length; i++)
            {
                affectedMesh[i].SetPropertyBlock(propertyblock);
            }

            for (int i = 0; i < affectedSkins.Length; i++)
            {
                affectedSkins[i].SetPropertyBlock(propertyblock);
            }

            if(!reverse)
            {
                if (dissolveTime > 1f)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (dissolveTime < 0f)
                {
                    Destroy(gameObject);
                }
            }
            
        }
    }
}
