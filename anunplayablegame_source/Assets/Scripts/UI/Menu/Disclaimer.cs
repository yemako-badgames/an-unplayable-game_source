using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class Disclaimer : MonoBehaviour
{
    [SerializeField] Animator animator;

    [Space]
    [SerializeField] Image fadeInBlackScreen;

    public UnityEvent disclaimerClosed;

    public static Disclaimer Instance;

    private void Awake()
    {
        // singleton code
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(this); }

        if (PlayerPrefs.GetInt("DisclaimerSeen") == 1)
        {
            DisableDisclaimer();
        }
    }

    public void SeenDisclaimer()
    {
        PlayerPrefs.SetInt("DisclaimerSeen", 1);
    }

    public void DisableDisclaimer()
    {
        disclaimerClosed.Invoke();
        this.gameObject.SetActive(false);
    }

    public void FadeInDisclaimer()
    {
        animator.Play("FadeIn");
    }

    // wrapper so i can fade in disclaimer when the intro video ends
    public void FadeInDisclaimer(VideoPlayer player)
    {
        FadeInDisclaimer();
    }

    public void FadeInComplete()
    {
        fadeInBlackScreen.enabled = false;
    }

}
