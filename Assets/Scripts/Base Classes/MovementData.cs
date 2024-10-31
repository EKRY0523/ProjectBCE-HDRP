using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "MovementData", menuName = "MovementData")]

public class MovementData : ScriptableObject
{

    public enum MovementMode
    {
        RigidBody,Transform
    }

    public Vector3 targetPosition;
    public Vector3 transformPosition;
    public MovementMode mode;
    public float duration;


    public void MoveCharacter(Rigidbody rb)
    {
        if(mode == MovementMode.RigidBody)
        {
            rb.AddForce((rb.transform.right * targetPosition.x) + (rb.transform.up * targetPosition.y) + (rb.transform.forward * targetPosition.z), ForceMode.VelocityChange);
        }
        else
        {
            rb.isKinematic = true;
            rb.transform.DOMove(targetPosition,duration);
        }
       
    }
}


