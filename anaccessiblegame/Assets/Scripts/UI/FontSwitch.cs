using TMPro;
using UnityEngine;


[RequireComponent (typeof(TextMeshProUGUI))]
public class FontSwitch : MonoBehaviour
{

    TextMeshProUGUI textObject;
    [SerializeField] TMP_FontAsset accessibleFont;
    TMP_FontAsset defaultFont;

    Settings settings;

    private void Awake()
    {
        textObject = GetComponent<TextMeshProUGUI>();

        // save font for later switching
        defaultFont = textObject.font;
    }

    private void Start()
    {
        settings = Settings.Instance;
        settings.fontChanged.AddListener(UpdateFont);

        // ensure correct font is active on start
        UpdateFont();
    }

    private void OnEnable()
    {
        if (settings != null) // null check in case it runs before settings is initialized
        {
            // ensure correct font is active whenever the object is enabled
            UpdateFont();
        }
    }

    void UpdateFont()
    {
        if (settings.useAccessibleFont)
        {
            textObject.font = accessibleFont;
        }
        else
        {
            textObject.font = defaultFont;
        }
    }
}
