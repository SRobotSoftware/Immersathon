using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject PlayButton;
    public GameObject BuildButton;

    public static float startTime;
    public static bool play;
    public static bool build = true;

    void Awake()
    {
        PlayButton = new GameObject();
        BuildButton = new GameObject();
    }
}