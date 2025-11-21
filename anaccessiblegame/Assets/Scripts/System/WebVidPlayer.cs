using UnityEngine;
using UnityEngine.Video;

public class WebVidPlayer : MonoBehaviour
{
    [SerializeField] string videoFileName;
    [SerializeField] VideoPlayer videoPlayer;

    private void Start()
    {
        PlayVideo();
    }

    public void PlayVideo()
    {
        if (videoPlayer == null) { return; }

        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        videoPlayer.url = videoPath;
        videoPlayer.Play();
    }
}
