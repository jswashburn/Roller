using UnityEngine;

public class RotationLocker : MonoBehaviour
{
    Quaternion _rotation;

    void Awake()
    {
        _rotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = _rotation;
    }
}
