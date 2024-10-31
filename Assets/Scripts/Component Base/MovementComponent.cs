using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MovementComponent", menuName = "ReusableComponent/Movement")]
public class MovementComponent : ReusableComponent
{
    public void MoveCharacter(Rigidbody rb, Vector3 direction)
    {
        rb.AddForce(direction-rb.linearVelocity,ForceMode.VelocityChange);
    }
    
}
