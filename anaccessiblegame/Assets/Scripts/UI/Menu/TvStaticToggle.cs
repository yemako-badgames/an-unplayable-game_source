using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TVStaticToggle : MonoBehaviour
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
        if (toggle.isOn != settings.tvStaticMuted) { toggle.isOn = settings.tvStaticMuted; }
    }
}
