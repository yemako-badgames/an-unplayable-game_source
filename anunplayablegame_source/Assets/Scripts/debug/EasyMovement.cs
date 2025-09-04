using UnityEngine;

public class EasyMovement : MonoBehaviour
{
    [SerializeField] bool active = false;

    [SerializeField] Movement movement;
    [SerializeField] Jump jump;
    [SerializeField] Animator controllerAnimator;

    // Update is called once per frame
    void Update()
    {
        if (!active) { return; }

        if (Input.GetKeyDown(KeyCode.A)) { movement.Move(-1); controllerAnimator.Play("DPadLeft"); }
        if (Input.GetKeyDown(KeyCode.D)) {  movement.Move(1); controllerAnimator.Play("DPadRight"); }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) { movement.Move(0); controllerAnimator.Play("Idle"); }

        if (Input.GetKeyDown(KeyCode.LeftShift)) { movement.Sprint(true); controllerAnimator.Play("RunPress"); }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { movement.Sprint(false); controllerAnimator.Play("Idle"); }

        if (Input.GetKeyDown(KeyCode.Space)) { jump.DoJump(true); controllerAnimator.Play("JumpPress"); }
        if (Input.GetKeyUp(KeyCode.Space)) { jump.DoJump(false); controllerAnimator.Play("Idle"); }
    }
}
