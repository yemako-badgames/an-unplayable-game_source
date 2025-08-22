using UnityEngine;
using System.Collections.Generic;

public class Trailer : MonoBehaviour
{
    [SerializeField] Color textLightColor;
    [SerializeField] Color blackScreenLightColor;
    [SerializeField] Color staticLightColor;
    [SerializeField] List<GameObject> trailerMessages = new List<GameObject>();
    [SerializeField] float blackScreenDuration = .25f;
    [SerializeField] CRTLightController lightController;
    [SerializeField] AudioClip messageDisappearSound;
    [SerializeField] AudioClip messageAppearSound;
    [SerializeField] AudioSource musicAudioSource;

    int currentMessage = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneController.Instance.TransitionToGameplay();
        }
    }

    private void Start()
    {
        lightController.ChangeLightColor(staticLightColor);
    }

    public void ShowNextMessage()
    {
        currentMessage++;
        if (currentMessage < trailerMessages.Count)
        {

            SoundController.Instance.PlaySoundEffect(messageAppearSound);
            trailerMessages[currentMessage].gameObject.SetActive(true);
            lightController.ChangeLightColor(textLightColor);
        }
    }

    public void HideMessage()
    {
        // hide current message
        trailerMessages[currentMessage].gameObject.SetActive(false);

        if (currentMessage < trailerMessages.Count-1) // some messages remain to be shown
        {
            SoundController.Instance.PlaySoundEffect (messageDisappearSound);

            // show brief black screen, delay before next message appears
            lightController.ChangeLightColor(blackScreenLightColor);
            Invoke(nameof(ShowNextMessage), blackScreenDuration);
        }
        else if (currentMessage ==  trailerMessages.Count-1) // last message in list
        {
            // show tv static
            SceneController.Instance.SetTvStatic(true);
            lightController.ChangeLightColor(staticLightColor);
            musicAudioSource.mute = true;
        }
    }
}
