using UnityEngine;

public class GameVersion : MonoBehaviour
{
    public static GameVersion Instance;

    public bool isDemo = false;
    public bool isSteam = false;


    private void Awake()
    {
        // singleton code
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(this); }
    }

    

}
