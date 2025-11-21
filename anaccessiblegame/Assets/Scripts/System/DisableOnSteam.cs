using UnityEngine;

public class DisableOnSteam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameVersion.Instance != null)
        {
            if (GameVersion.Instance.isSteam)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
