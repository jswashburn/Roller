using UnityEngine;

namespace Roller.Extensions.Unity
{
    public static class VectorExtensions
    {
        public static Vector3 With(this Vector3 original,
            float? newX = null, float? newY = null, float? newZ = null)
        {
            return new Vector3(
                newX ?? original.x,
                newY ?? original.y,
                newZ ?? original.z
            );
        }

        public static Vector3 WithOffset(this Vector3 original,
            float? xOffset = null, float? yOffset = null, float? zOffset = null)
        {
            return new Vector3(
                original.x + xOffset ?? original.x,
                original.y + yOffset ?? original.y,
                original.z + zOffset ?? original.z
            );
        }

        public static bool IsGrounded(this Vector3 original, Collider groundCheckCollider)
        {
            return Physics.Raycast(
                original,
                Vector3.down,
                groundCheckCollider.bounds.extents.y + 0.1f,
                Physics.DefaultRaycastLayers,
                QueryTriggerInteraction.Ignore
            );
        }
    }
}