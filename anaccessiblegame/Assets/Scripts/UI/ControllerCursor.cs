using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(VirtualMouseInput))]
public class ControllerCursor : MonoBehaviour
{
    RectTransform rect;
    VirtualCursorCopy virtualMouseInput;

    [SerializeField] Image cursorImage;
    [Space]
    [SerializeField] float deadzone = .35f;
    [Space]
    [SerializeField] float cursorSpeed_atDesiredSize = 300;
    [Space]
    [SerializeField] float desiredWidth = 800;
    [SerializeField] float desiredHeight = 600;

    float outOfBoundsLeewayMult = .92f;

    bool controllerCursorActive = false;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        virtualMouseInput = GetComponent<VirtualCursorCopy>();
    }

    // Update is called once per frame
    void Update()
    {
        // show mouse cursor if there is mouse movement
        if (Mouse.current != null && Mouse.current.delta.ReadValue().magnitude > 0)
        {
            controllerCursorActive = false;
            Cursor.visible = true;
            cursorImage.enabled = false;
        }
        // hide mouse cursor if there is gamepad input
        else if (Gamepad.current != null && (Gamepad.current.leftStick.ReadValue().magnitude > deadzone ||
            Gamepad.current.buttonSouth.wasPressedThisFrame))
        {
            // only hide the hardware cursor on the first frame of gamepad input
            if (!controllerCursorActive)
            {
                Cursor.visible = false;

                // move controller cursor to default position (center of screen by default)
                rect.anchoredPosition = new Vector2(0,0);
                InputState.Change(virtualMouseInput.virtualMouse.position, new Vector2(Screen.width/2, Screen.height/2));

                cursorImage.enabled = true;
                controllerCursorActive = true;
            }
        }

        // gamepad cursor bounds clamping
        if (!Cursor.visible)
        {
            virtualMouseInput.cursorSpeed = cursorSpeed_atDesiredSize * (Screen.height / desiredHeight);
            
            // out of bounds on the right
            if ( virtualMouseInput.virtualMouse.position.ReadValue().x > Screen.width / 2f + outOfBoundsLeewayMult * (Screen.height * (desiredWidth /desiredHeight) / 2f))
            {
                InputState.Change(virtualMouseInput.virtualMouse.position, new Vector2(
                    Screen.width / 2f + outOfBoundsLeewayMult * (Screen.height * (desiredWidth / desiredHeight) / 2f),
                    virtualMouseInput.virtualMouse.position.ReadValue().y));

            }
            // out of bounds on the left
            else if ( virtualMouseInput.virtualMouse.position.ReadValue().x < Screen.width / 2f - outOfBoundsLeewayMult * (Screen.height * (desiredWidth / desiredHeight) / 2f))
            {
                InputState.Change(virtualMouseInput.virtualMouse.position, new Vector2(
                    Screen.width / 2f - outOfBoundsLeewayMult * (Screen.height * (desiredWidth / desiredHeight) / 2f),
                    virtualMouseInput.virtualMouse.position.ReadValue().y));
            }
        }
    }
}
