using UnityEngine;

public class DisableOnWeb : MonoBehaviour
{
    private void Start()
    {
        // disable window resizing on webgl builds
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
