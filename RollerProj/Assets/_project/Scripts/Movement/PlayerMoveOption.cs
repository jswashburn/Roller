using UnityEngine;

public class PlayerMoveOption : IMoveOption
{
    public Vector3 MoveDirection { get; set; }
    public bool JumpRequested { get; set; }
    public bool SlowDownRequested { get; set; }
}