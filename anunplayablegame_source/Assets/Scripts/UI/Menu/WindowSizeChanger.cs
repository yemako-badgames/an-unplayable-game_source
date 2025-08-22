using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowSizeChanger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resolutionDisplay;

    private void Start()
    {
        // disable window resizing on webgl builds
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        resolutionDisplay.text = $"{Screen.width} x {Screen.height}";

    }
}
