using UnityEngine;

public class RestartLevelButton : MonoBehaviour
{
    public void StartOver()
    {
        RestartLevel.Restart.LoadLevel();

    }
}
