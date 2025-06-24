using UnityEngine;

public class RotateToCam : MonoBehaviour
{
    public Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void LateUpdate()
    {
        if (cam != null)
        {
            // Make the canvas face the camera
            transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        }
    }
    
}
