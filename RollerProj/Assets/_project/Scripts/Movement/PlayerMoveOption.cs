using UnityEngine;

public class PlayerMoveOption : IMoveOption // test comment for git
{
    public Vector3 MoveDirection { get; set; }
    public bool JumpRequested { get; set; }
}