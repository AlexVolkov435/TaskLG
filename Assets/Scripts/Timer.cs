using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeStart;

    [SerializeField] private TextMeshProUGUI _textTimer;

    public bool IsRunning { get; set; }

    private void Start()
    {
        _textTimer.text = _timeStart.ToString("F2");
    }

    private void FixedUpdate()
    {
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
