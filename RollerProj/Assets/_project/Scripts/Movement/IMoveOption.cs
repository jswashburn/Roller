using UnityEngine;

public interface IMoveOption
{
    Vector3 MoveDirection { get; set; }
    bool JumpRequested { get; set; }
}