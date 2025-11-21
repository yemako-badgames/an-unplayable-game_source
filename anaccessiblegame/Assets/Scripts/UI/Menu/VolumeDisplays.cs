using TMPro;
using UnityEngine;

public class VolumeDisplays : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameVolText;
    [SerializeField] TextMeshProUGUI musicVolText;
    [SerializeField] TextMeshProUGUI sfxVolText;

    // Update is called once per frame
    void Update()
    {
        Settings settings = Settings.Instance;

        if (gameVolText != null && gameVolText.isActiveAndEnabled) { gameVolText.text = ((settings.gameVolume / settings.volumeMax) * 100).ToString(); }

        if (musicVolText != null && musicVolText.isActiveAndEnabled) { musicVolText.text = ((settings.musicVolume / settings.volumeMax) * 100).ToString(); }

        if (sfxVolText != null && sfxVolText.isActiveAndEnabled) { sfxVolText.text = ((settings.sfxVolume / settings.volumeMax) * 100).ToString(); }
    }
}
