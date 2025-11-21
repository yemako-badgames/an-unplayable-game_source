using UnityEngine;

public class TVStaticAudio : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // configure tv static sound based on settings on game start
        audioSource.mute = Settings.Instance.tvStaticMuted;
    }
}
