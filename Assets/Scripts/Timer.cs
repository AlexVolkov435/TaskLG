using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeStart;

    [SerializeField] private TextMeshProUGUI _textTimer;

    private bool _isTimerRunning  = false;

    private void Start()
    {
        _textTimer.text = _timeStart.ToString("F2");
    }

    private void FixedUpdate()
    {
        if(_isTimerRunning == true)
        {
            _timeStart += Time.deltaTime;
            _textTimer.text = _timeStart.ToString("F2");
        }
    }
}
