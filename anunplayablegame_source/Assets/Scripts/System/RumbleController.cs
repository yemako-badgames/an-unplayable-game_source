using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleController : MonoBehaviour
{
    [SerializeField] float leftRumbleStrength = .25f;
    [SerializeField] float rightRumbleStrength = .25f;

    [SerializeField] Animator animator;

    public static RumbleController Instance;
    private void Awake()
    {
        // singleton code
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(this); }
    }

    /// <summary>
    /// makes the controller start rumbling
    /// </summary>
    public void StartRumble()
    {
        // do nothing if player is not using controller cursor
        if (Cursor.visible) { return; }

        Gamepad.current.SetMotorSpeeds(leftRumbleStrength, rightRumbleStrength);

        animator.Play("Rumble");
    }

    public void StopRumble()
    {
        InputSystem.PauseHaptics();
        InputSystem.ResetHaptics();
    }

}
