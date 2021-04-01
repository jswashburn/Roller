using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 With(this Vector3 original,
        float? newX = null, float? newY = null, float? newZ = null)
        => new Vector3(
            newX ?? original.x,
            newY ?? original.y,
            newZ ?? original.z
        );

    public static Vector3 WithOffset(this Vector3 original,
        float? xOffset = null, float? yOffset = null, float? zOffset = null)
        => new Vector3(
            original.x + xOffset ?? original.x,
            original.y + yOffset ?? original.y,
            original.z + zOffset ?? original.z
        );

    // Is this vector 'grounded' with respect to groundCheckCollider?
    public static bool IsGrounded(this Vector3 original, Collider groundCheckCollider)
        => Physics.Raycast(
            origin: original,
            direction: Vector3.down,
            maxDistance: groundCheckCollider.bounds.extents.y + 0.1f,
            layerMask: Physics.DefaultRaycastLayers,
            queryTriggerInteraction: QueryTriggerInteraction.Ignore
        );
}
