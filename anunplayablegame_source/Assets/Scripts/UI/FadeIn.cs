using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(Animator))]
public class FadeIn : MonoBehaviour
{
    [HideInInspector]
    public float fadeProgress = 0;

    [SerializeField] Image blackScreen;
    [SerializeField] AudioSource tvStaticAudioSource;
    [SerializeField] VideoPlayer introVideo;

    private void Start()
    {
        // disclaimer not seen, fade in after disclaimer is closed
        if (PlayerPrefs.GetInt("DisclaimerSeen") != 1)
        {
            Disclaimer.Instance.disclaimerClosed.AddListener(StartFadeIn);
            introVideo.loopPointReached += DisableIntroVid;
            introVideo.loopPointReached += Disclaimer.Instance.FadeInDisclaimer;
        }
        // disclaimer seen already, fade in after intro video
        else
        {
            introVideo.loopPointReached += StartFadeIn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if fade has started and is not complete,
        if (fadeProgress != 0 && fadeProgress < 1)
        {
            // fade in audio
            tvStaticAudioSource.volume = fadeProgress;
            
            // fade out blackscreen
            Color newColor = blackScreen.color;
            newColor.a = 1 - fadeProgress;
            blackScreen.color = newColor;
        }
        // fade done, remove black screen so player can click on menu stuff
        else if (fadeProgress >= 1 && blackScreen.enabled)
        {
            blackScreen.enabled = false;
        }
    }

    public void StartFadeIn()
    {
        DisableIntroVid();
        GetComponent<Animator>().Play("FadeIn");
    }

    // need this parameter to be called on logo vid end
    public void StartFadeIn(VideoPlayer player)
    {
        StartFadeIn();
    }

    void DisableIntroVid()
    {
        if (introVideo.enabled == true)
        {
            introVideo.enabled = false;
        }
    }

    public void DisableIntroVid(VideoPlayer player)
    {
        DisableIntroVid();
    }

}
