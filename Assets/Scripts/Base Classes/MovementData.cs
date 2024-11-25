using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "MovementData", menuName = "MovementData")]

public class MovementData : ScriptableObject
{

    public enum MovementMode
    {
        RigidBody,CharacterController
    }

    public Vector3 targetPosition;
    public Vector3 transformPosition;
    public MovementMode mode;
    public float duration;
    public bool passThrough;

    public void MoveCharacter(Rigidbody rb)
    {
        if(mode == MovementMode.RigidBody)
        {
            rb.AddForce(((rb.transform.right * targetPosition.x) + (rb.transform.up * targetPosition.y) + (rb.transform.forward * targetPosition.z))-rb.linearVelocity, ForceMode.VelocityChange);
        }
        else
        {
            rb.isKinematic = true;
            rb.transform.DOMove(targetPosition,duration);
        }
    }

    public void MoveCharacter(CharacterController cc)
    {
        if(!passThrough)
        {
            cc.Move((cc.transform.right * targetPosition.x) + (cc.transform.up * targetPosition.y) + (cc.transform.forward * targetPosition.z));
        }
        else
        {
            cc.transform.position = cc.transform.position+ (cc.transform.right * targetPosition.x) + (cc.transform.up * targetPosition.y) + (cc.transform.forward * targetPosition.z);
        }
    }

}


