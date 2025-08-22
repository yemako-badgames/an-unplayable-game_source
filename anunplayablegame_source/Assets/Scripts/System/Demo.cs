using UnityEngine;

public class Demo : MonoBehaviour
{
    public static Demo Instance;

    public bool isDemo = false;


    private void Awake()
    {
        // singleton code
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(this); }
    }

    

}
