using UnityEngine;

public class Track : MonoBehaviour
{
    public Transform cycleTrigger;

    [SerializeField] Animator _animator;
    [SerializeField] MeshRenderer _mesh;
    [SerializeField] Collider _collider;

    public bool Despawned => gameObject.activeSelf;

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void AppearAt(Vector3 pos)
    {
        transform.position = pos;
        _animator.SetTrigger("Appear");
    }

    public override string ToString()
    {
        return transform.name;
    }
}
