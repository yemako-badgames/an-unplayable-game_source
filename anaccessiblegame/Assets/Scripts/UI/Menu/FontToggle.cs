using UnityEngine;
using UnityEngine.UI;

public class FontToggle : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    Settings settings;

    private void Start()
    {
        settings = Settings.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        // if toggle does not match setting, make them match
        if (toggle.isOn != settings.useAccessibleFont) { toggle.isOn = settings.useAccessibleFont; }
    }
}
