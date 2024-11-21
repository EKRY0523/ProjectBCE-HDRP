using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MovementComponent", menuName = "ReusableComponent/Movement")]
public class MovementComponent : ReusableComponent
{
    public void MoveCharacter(Rigidbody rb, Vector3 direction)
    {
        //direction.y = -9.81f;
        rb.AddForce(direction-rb.linearVelocity,ForceMode.VelocityChange);
        //rb.AddForce(direction - rb.linearVelocity, ForceMode.VelocityChange);
    }

    public void MoveCharacter(CharacterController controller,Vector3 direction,float speed)
    {
        controller.Move(direction * speed* Time.deltaTime);
    }
}
