using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _winner;

    private void Start()
    {
        _winner.SetActive(false);
    }

    private void OnTriggerEnter()
    {
        _timer.IsRunning = false;
        _winner.SetActive(true);
        Time.timeScale = 0;
    }
}
