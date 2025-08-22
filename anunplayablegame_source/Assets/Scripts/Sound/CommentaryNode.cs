using TMPro;
using UnityEngine;

public class CommentaryNode : MonoBehaviour
{
    public AudioClip audioClip;
    public TextMeshProUGUI text;
    [Space]
    [SerializeField] bool includeInDemo = false;
    [SerializeField] bool excludeInFullGame = false;

    CommentaryController commentaryPlayer;

    private void Start()
    {
        commentaryPlayer = CommentaryController.Instance;
    }

    public void Play()
    {
        if (commentaryPlayer == null) { return; }

        commentaryPlayer.PlayCommentary(audioClip, text);
    }

    private void OnEnable()
    {
        
        if (Demo.Instance != null)
        {
            // if this is the demo build, and this node should NOT be included in the demo,
            // disable this node
            if (Demo.Instance.isDemo && !includeInDemo)
            {
                gameObject.SetActive(false);
                return;
            }
            // if this is the full game and this node should NOT be included in the full game,
            // disable this node
            else if (!Demo.Instance.isDemo && excludeInFullGame)
            {
                gameObject.SetActive(false);
                return;
            }
        }


        // activate onscreen node controller if this is an onscreen node
        OnscreenCommNode onscreenNode = GetComponent<OnscreenCommNode>();
        if (onscreenNode != null)
        {
            onscreenNode.Enable();
        }

        // activate controller if this is an onscreen node in the ui
        OnscreenUiCommNode onscreenUINode = GetComponent<OnscreenUiCommNode>();

        if (onscreenUINode != null)
        {
            onscreenUINode.Enable();
        }
    }

    private void OnDisable()
    {
        OnscreenCommNode onscreenNode = GetComponent<OnscreenCommNode>();
        if (onscreenNode != null)
        {
            onscreenNode.Disable();
        }

        OnscreenUiCommNode onscreenUINode = GetComponent<OnscreenUiCommNode>();

        if (onscreenUINode != null)
        {
            onscreenUINode.Disable();
        }
    }
}
