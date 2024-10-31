using UnityEngine;
using UnityEngine.VFX;
public class VFXHandler : MonoBehaviour
{
    VisualEffect vfx;
    public float maxValue;
    public float minValue;
    public float increment;
    private void Awake()
    {
        vfx = GetComponent<VisualEffect>();

        vfx.SetFloat("Step",1f);
    }
    private void Update()
    {
        if (vfx.GetFloat("Step")>=minValue)
        {
            vfx.SetFloat("Step", vfx.GetFloat("Step") - Time.deltaTime *increment);
            
        }
        else
        {
            vfx.SetFloat("VoronoiPower", vfx.GetFloat("VoronoiPower") + increment/2);
        }
    }
}
