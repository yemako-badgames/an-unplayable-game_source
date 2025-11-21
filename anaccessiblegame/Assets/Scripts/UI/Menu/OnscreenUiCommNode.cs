using UnityEngine;
using UnityEngine.UI;

public class OnscreenUiCommNode : MonoBehaviour
{
    [SerializeField] OnscreenUiCommIcon onscreenIcon;
    [SerializeField] CommentaryNode commentaryNode;
    [SerializeField] RumbleMessenger rumble;
    [SerializeField] Image clickHitbox;

    // Update is called once per frame
    void Update()
    {
        if (onscreenIcon.gameObject.activeInHierarchy)
        {
            clickHitbox.enabled = true;
        }
        else { clickHitbox.enabled = false; }
    }

    public void OnHover()
    {
        onscreenIcon.OnHover();

        rumble.Rumble();
    }

    public void OnUnhover()
    {
        onscreenIcon.OnUnhover();
    }

    public void Play()
    {
        commentaryNode.Play();
        rumble.Rumble();

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
