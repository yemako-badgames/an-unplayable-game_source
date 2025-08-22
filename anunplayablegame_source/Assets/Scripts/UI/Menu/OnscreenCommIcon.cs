using UnityEngine;

public class OnscreenCommIcon : MonoBehaviour
{
    [SerializeField] Camera gameCam;
    [SerializeField] PauseMenu pauseMenu;
    [Space]
    [SerializeField] bool isGameplayNode = true;
    [SerializeField] float offscreenX = 7.9f;
    [Space]
    [SerializeField] Animator animator;

    public bool isClickable { get; private set; } = false;

    public Vector3 displacementFromCam { get; private set; }

    // Update is called once per frame
    void Update()
    {
        displacementFromCam = transform.position - gameCam.transform.position;

        isClickable = true;

        // cannot click gameplay nodes while pause menu is open
        if (isGameplayNode && pauseMenu.isOpen)
        {
            isClickable = false;
        }
        // node becomes unclickable if offscreen
        else if (Mathf.Abs(displacementFromCam.x) > offscreenX)
        {
            isClickable = false;
        }
    }

    public void OnHover()
    {
        // do not play anim if not clickable
        if (!isClickable) { return; }

        animator.Play("Grow");
    }

    public void OnUnhover()
    {
        // do not play anim if not clickable
        if (!isClickable) { return; }

        animator.Play("Shrink");
    }
}
