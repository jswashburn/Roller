using UnityEngine;

public static class RigidBodyExtensions
{
    public static void Jump(this Rigidbody original, float force)
        => original.AddForce(Vector3.up * force);

    public static void MoveTowards(this Rigidbody original, Vector3 towards, float speed)
        => original.AddForce(towards * speed);

    public static void MoveTowards(this Rigidbody original, Vector3 towards, float speed, float maxSpeed)
    {
        original.AddForce(towards * speed);
        original.ClampSpeed(maxSpeed);
    }

    public static void ClampSpeed(this Rigidbody original, float maxSpeed)
    {
        // If we go over our max speed, normalize our velocity and re-scale by max speed
        if (original.velocity.magnitude > maxSpeed)
            original.velocity = original.velocity.normalized * maxSpeed;
    }
}

    #region Boomer legacy code
    // public static void Stop(this Rigidbody original)
    // {
    //     original.velocity = Vector3.zero;
    //     original.angularVelocity = Vector3.zero;
    // }

    // public static void SlowToStop(this Rigidbody original, 
    //     ref Vector3 currentVelocity, ref Vector3 currentAngularVelocity,
    //     float smoothTime, float immediateStopSpeed)
    // {
    //     original.velocity = Vector3.SmoothDamp(original.velocity, Vector3.zero, ref currentVelocity, smoothTime);
    //     original.angularVelocity = Vector3.SmoothDamp(original.angularVelocity, Vector3.zero, ref currentAngularVelocity, smoothTime);

    //     // Immediately stop when speed is less than immediateStopSpeed
    //     if (Mathf.Abs(original.velocity.x) < immediateStopSpeed)
    //         original.Stop();
    // }

    // public static void JumpTowards(this Rigidbody original, float force, Vector3 where)
    //     => original.AddForce((where + Vector3.up).normalized * force); // Bisect the where vector and the up vector and scale by force
    #endregion