using UnityEngine;

public class OnscreenCommNode : MonoBehaviour
{
    [SerializeField] OnscreenCommIcon onscreenIcon;
    [SerializeField] CommentaryNode commentaryNode;
    [SerializeField] RumbleMessenger rumble;
    [SerializeField] Transform tvScreenTransform;
    [Space]
    // how many times bigger the game world is than the screen
    [SerializeField] float gameScaleMult = 14.39f;
    [SerializeField] float zDisplacement = .9f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = tvScreenTransform.position + (onscreenIcon.displacementFromCam / gameScaleMult);
        newPos.z = zDisplacement;

        transform.position = newPos;
    }

    public void OnHover()
    {
        onscreenIcon.OnHover();

        if (onscreenIcon.isClickable)
        {
            rumble.Rumble();
        }
    }

    public void OnUnhover()
    {
        onscreenIcon.OnUnhover();
    }

    public void Play()
    {
        if (onscreenIcon.isClickable)
        {
            commentaryNode.Play();
            rumble.Rumble();
        }
    }

    public void Disable()
    {
        if (onscreenIcon == null) { return; }
        onscreenIcon.gameObject.SetActive(false);
    }

    public void Enable()
    {
        if (onscreenIcon == null) { return; }
        onscreenIcon.gameObject.SetActive(true);
    }
}
