using UnityEngine;

namespace Roller.Movement
{
    public class PlayerMoveOption : IMoveOption
    {
        public Vector3 MoveDirection { get; set; }
        public bool JumpRequested { get; set; }
    }
}