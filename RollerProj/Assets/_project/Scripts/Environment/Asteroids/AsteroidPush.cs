using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AsteroidPush : MonoBehaviour
{
    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        
    }
}
