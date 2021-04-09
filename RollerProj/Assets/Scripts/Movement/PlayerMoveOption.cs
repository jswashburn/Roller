using UnityEngine;

namespace Roller.Movement
{
    public class PlayerMoveOption : IMoveOption
    {
        public bool JumpRequested { get; set; }
        public Vector3 MoveDirection { get; set; }
    }
}