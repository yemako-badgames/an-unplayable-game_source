using UnityEngine;

/// <summary>
/// a helper script meant to call upon the rumblecontroller without a reference, since it is a singleton
/// </summary>
public class RumbleMessenger : MonoBehaviour
{
    public void Rumble()
    {
        if (RumbleController.Instance == null) { return; }

        RumbleController.Instance.StartRumble();
    }
}
