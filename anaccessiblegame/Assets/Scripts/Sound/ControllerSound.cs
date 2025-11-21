using UnityEngine;
using System.Collections.Generic;

public class ControllerSound : MonoBehaviour
{
    [SerializeField] List<AudioClip> hover = new List<AudioClip>();
    [SerializeField] List<AudioClip> press = new List<AudioClip>();
    [SerializeField] List<AudioClip> release= new List<AudioClip>();
    [Space]
    [SerializeField] float pitchVariance = .05f;
    [SerializeField] float volume = .9f;

    public void PlayHoverSound()
    {
        AudioClip soundEffect = hover[Random.Range(0, hover.Count)];
        if (SoundController.Instance != null) { SoundController.Instance.PlaySoundEffect(soundEffect, pitchVariance, volume); }
    }

    public void PlayPressSound()
    {
        AudioClip soundEffect = press[Random.Range(0, press.Count)];
        if (SoundController.Instance != null) { SoundController.Instance.PlaySoundEffect(soundEffect, pitchVariance, volume); }
    }

    public void PlayReleaseSound()
    {
        AudioClip soundEffect = release[Random.Range(0, release.Count)];
        if (SoundController.Instance != null) { SoundController.Instance.PlaySoundEffect(soundEffect, pitchVariance, volume); }
    }

}
