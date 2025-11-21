using Unity.Cinemachine;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] PlayerControl playerControl;
    [SerializeField] Transform initialSpawnTransform;
    [SerializeField] PlayerAnimationController playerAnimController;
    [Space]
    [SerializeField] CinemachineCamera cinemachineCam;
    [Space]
    [SerializeField] AudioClip respawnSound;

    Vector2 currentSpawn;

    public static SpawnController Instance;

    private void Awake()
    {
        // singleton code
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(this); }



        SetSpawn(initialSpawnTransform.position);
    }

    public void SetSpawn(Vector2 newSpawnPos)
    {
        currentSpawn = newSpawnPos;
    }

    /// <summary>
    /// respawns player at a specified position
    /// </summary>
    /// <param name="spawnPos"></param>
    public void Respawn(Vector2 spawnPos)
    {
        cinemachineCam.PreviousStateIsValid = false;
        player.transform.position = spawnPos;
        playerControl.EnableControl();

        // ensures player is on the ground when they spawn
        Grounded groundDetector = player.GetComponentInChildren<Grounded>();
        if (groundDetector != null)
        {
            groundDetector.isGrounded = true;
        } 
            
    }

    public void Respawn(Vector2 spawnPos, bool playSound)
    {
        if (playSound)
        {
            SoundController.Instance.PlaySoundEffect(respawnSound);
        }
        Respawn(spawnPos);
    }

    /// <summary>
    /// overload of respawn method that respawns player at current registered spawn point
    /// </summary>
    public void Respawn()
    {
        Respawn(currentSpawn, true);

        playerAnimController.FaceSprite(1);
    }

    public void Spawn()
    {
        SetSpawn(initialSpawnTransform.position);
        Respawn(currentSpawn);
    }
}
