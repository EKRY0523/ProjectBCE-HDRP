using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class ShakeOnInstantiate : MonoBehaviour
{
    public CinemachineCamera cinemachineCam; 
    public float shakeIntensity = 2f;
    public float shakeDuration = 0.5f;

    private CinemachineBasicMultiChannelPerlin perlinNoise;

    void Start()
    {
        cinemachineCam = FindFirstObjectByType<CinemachineCamera>();

        if (cinemachineCam != null)
        {
            perlinNoise = cinemachineCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
            if (perlinNoise != null)
            {
                StartCoroutine(ShakeCamera());
            }
        }
    }

    private void OnDestroy()
    {
        perlinNoise.AmplitudeGain = 0f;
    }
    private IEnumerator ShakeCamera()
    {
        perlinNoise.AmplitudeGain = shakeIntensity;
        yield return new WaitForSeconds(shakeDuration);
        perlinNoise.AmplitudeGain = 0f;
    }
}