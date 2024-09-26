using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private void OnTriggerEnter()
    {
        _timer.IsRunning = true;
    }
}
