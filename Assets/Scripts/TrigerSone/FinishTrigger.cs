using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _winner;
    [SerializeField] private AudioSource _clip;

    private void Start()
    {
        _winner.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _clip.Play();
            _timer.IsRunning = false;
            _winner.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
