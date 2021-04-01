using UnityEngine;

public static class RigidBodyExtensions
{
    public static void Jump(this Rigidbody original, float force)
    {
        original.AddForce(Vector3.up * force);
    }

    public static void MoveTowards(this Rigidbody original, Vector3 towards, float speed)
    {
        original.AddForce(towards * speed);
    }

    public static void MoveTowards(this Rigidbody original, Vector3 towards, float speed, float maxSpeed)
    {
        original.AddForce(towards * speed);
        original.ClampSpeed(maxSpeed);
    }

    public static void ClampSpeed(this Rigidbody original, float maxSpeed)
    {
        // If we go over our max speed, normalize our velocity and re-scale by max speed
        if (original.velocity.magnitude > maxSpeed)
        {
            original.velocity = original.velocity.normalized * maxSpeed;
        }
    }
}