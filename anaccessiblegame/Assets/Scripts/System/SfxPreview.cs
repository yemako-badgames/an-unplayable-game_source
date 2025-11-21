using UnityEngine;

public class SfxPreview : MonoBehaviour
{
    [SerializeField] bool canPlayPreview = false;
    [SerializeField] AudioClip previewSound;

    SoundController soundController;

    private void Start()
    {
        if (SoundController.Instance != null) {soundController = SoundController.Instance;}
    }

    public void SetPreviewEnabled(bool isEnabled)
    {
        canPlayPreview = isEnabled;
    }

    public void PlayPreviewSound()
    {

        if (canPlayPreview)
        { soundController.PlayMenuSoundEffect(previewSound, true); }
    }

}
