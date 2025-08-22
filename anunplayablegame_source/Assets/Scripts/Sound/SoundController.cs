using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController Instance;

    [SerializeField] AudioSource sfxAudioSourcePrefab;
    [SerializeField] AudioSource musicAudioSource;

    public bool soundEffectsEnabled { get; private set; } = false;
    public bool menuSoundsEnabled { get; private set; } = true;

    private void Awake()
    {
        // singleton code
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(this); }
    }

    private void Start()
    {
        // enable on start so that menu slider sounds don't play on awake
        menuSoundsEnabled = true;
    }

    public void PlaySoundEffect(AudioClip audioClip)
    {
        // do nothing if sound effects are disabled
        if (!soundEffectsEnabled) { return; }

        AudioSource audioSource = Instantiate(this.sfxAudioSourcePrefab, transform);

        audioSource.clip = audioClip;
        audioSource.Play();

        Destroy(audioSource.gameObject, audioSource.clip.length +.1f);
    }

    public void PlaySoundEffect(AudioClip audioClip,float pitchVariance)
    {
        // do nothing if sound effects are disabled
        if (!soundEffectsEnabled) { return; }

        AudioSource audioSource = Instantiate(this.sfxAudioSourcePrefab, transform);

        // randomize pitch before playing
        audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance);

        audioSource.clip = audioClip;
        audioSource.Play();

        Destroy(audioSource.gameObject, audioSource.clip.length + .1f);
    }

    public void PlaySoundEffect(AudioClip audioClip, float pitchVariance, float volume)
    {
        // do nothing if sound effects are disabled
        if (!soundEffectsEnabled) { return; }

        AudioSource audioSource = Instantiate(this.sfxAudioSourcePrefab, transform);

        // randomize pitch before playing
        audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        Destroy(audioSource.gameObject, audioSource.clip.length + .1f);
    }

    public void PlayMenuSoundEffect(AudioClip audioClip)
    {
        if (menuSoundsEnabled)
        {
            AudioSource audioSource = Instantiate(this.sfxAudioSourcePrefab, transform);

            audioSource.clip = audioClip;
            audioSource.Play();

            Destroy(audioSource.gameObject, audioSource.clip.length + .1f);
        }
    }

    public void PlayMenuSoundEffect(AudioClip audioClip, bool ignoreDisabledStatus)
    {
        if (ignoreDisabledStatus || menuSoundsEnabled)
        {
            AudioSource audioSource = Instantiate(this.sfxAudioSourcePrefab, transform);

            audioSource.clip = audioClip;
            audioSource.Play();

            Destroy(audioSource.gameObject, audioSource.clip.length + .1f);
        }
    }

    public void SetSoundEffectsEnabled(bool enable)
    {
        soundEffectsEnabled = enable;
    }

    public void SetMusicEnabled(bool enable)
    {
        musicAudioSource.mute = !enable;

        if (enable) { musicAudioSource.Play(); }
    }

    public void StopAllSounds()
    {
        foreach (AudioSource audioSource in FindObjectsByType<AudioSource>(FindObjectsSortMode.None))
        {
            audioSource.Stop();
        }
    }

    public void SetMenuSoundsEnabled(bool enable)
    {
        menuSoundsEnabled = enable;
    }

}
