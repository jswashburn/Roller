using UnityEngine;

namespace Roller.Movement
{
    public interface IMoveOption
    {
        Vector3 MoveDirection { get; }
    }
}