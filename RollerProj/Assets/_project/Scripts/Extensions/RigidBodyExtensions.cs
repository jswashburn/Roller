using UnityEngine;

public static class RigidBodyExtensions
{
    public static void Jump(this Rigidbody original, float force)
    {
        original.AddForce(Vector3.up * force);
    }

    public static void MoveTowards(this Rigidbody original, Vector3 where, float maxSpeed)
    {
        original.AddForce(where);
        original.ClampSpeed(maxSpeed);
    }

    public static void ClampSpeed(this Rigidbody original, float maxSpeed)
    {
        float currentSpeed = original.velocity.magnitude;
        if (currentSpeed > maxSpeed)
        {
            Vector3 clamped = original.velocity.normalized * maxSpeed;
            original.velocity = clamped;
        }
    }
}