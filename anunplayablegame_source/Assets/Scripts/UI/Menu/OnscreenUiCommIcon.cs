using UnityEngine;

public class OnscreenUiCommIcon : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void OnHover()
    {
        animator.Play("Grow");
    }

    public void OnUnhover()
    {
        animator.Play("Shrink");
    }
}
