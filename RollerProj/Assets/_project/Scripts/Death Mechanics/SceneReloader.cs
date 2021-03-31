using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // TODO: Support ignoring certain colliders
    
    void OnTriggerEnter(Collider other) => SceneManager.LoadScene(0);
}
