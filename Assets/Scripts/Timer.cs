using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeStart;
    private float _countdownTime = 3;

    [SerializeField] private TextMeshProUGUI _textTimer;
    [SerializeField] private TextMeshProUGUI _textcountdownTime;
    [SerializeField] private GameObject _menueStart;
    [SerializeField] private PlayerController _player;

    public bool IsRunning { get; set; }

    private void Start()
    {
        _textTimer.text = _timeStart.ToString("F2");
        _textcountdownTime.text = _countdownTime.ToString();
        _menueStart.SetActive(true);
    }

    private void FixedUpdate()
    {
        _countdownTime -= Time.deltaTime;
        _textcountdownTime.text = Mathf.Round(_countdownTime).ToString();

        if (_countdownTime > 0)
        {
            _player.GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            _player.GetComponent<PlayerController>().enabled = true;
            _menueStart.SetActive(false);
        }

        if (IsRunning == true)
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
        _timeStart += Time.deltaTime;
        _textTimer.text = _timeStart.ToString("F2");
    }
}
