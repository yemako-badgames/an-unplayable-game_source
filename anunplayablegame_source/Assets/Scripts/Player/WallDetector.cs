using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class WallDetector : MonoBehaviour
{
    public bool againstWall { get; private set; } = false;

    //NOTE: this detects walls in front of the player in the direction they are moving

    [SerializeField] Movement movement;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // stop x velocity when running into a wall
        if (collision.gameObject.layer == 7)
        {
            movement.StopXVelocity();
            againstWall = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            againstWall = false;

        }
    }

}
