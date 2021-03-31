using UnityEngine;

public class Track : MonoBehaviour
{
    public Animator animator;

    public void Disappear()
    {
        animator.SetTrigger("Disappear");
    }

    // Called as soon as "Disappear" animation finishes
    public void DeActivate()
    {
        Debug.Log("Deactivate called");
        gameObject.SetActive(false);
    }

    public void Appear(Vector3 where)
    {
        gameObject.SetActive(true);
        transform.position = where;
        animator.SetTrigger("Appear");
    }

}
