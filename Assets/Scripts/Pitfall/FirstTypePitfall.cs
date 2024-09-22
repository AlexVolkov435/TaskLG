using System.Collections;
using UnityEngine;

public class FirstTypePitfall : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _timeRefresh = 5f;

    private IEnumerator _IEnumerator;

    private Renderer _renderer;

    private Color _color;
    private Color _colorStart;
  
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _IEnumerator = Counter(_timeRefresh);
            StartCoroutine(_IEnumerator);
        }
    }

    private IEnumerator Counter(float delayRefresh)
    {
        float pauseAfterDamage = 1.0f;
        float pause = 0.5f;

        var wait = new WaitForSeconds(pause);
        var rechargeTime = new WaitForSeconds(delayRefresh);

        bool isPitfall = true;

        while (isPitfall)
        {
            Color color = ChangeColor();

            Invoke("DoDamage", pauseAfterDamage);

            yield return wait;

            _renderer.material.color = Color.red;

            yield return wait;

            _renderer.material.color = color;

            yield return rechargeTime;
        }
    }

    private Color ChangeColor()
    {
        byte colorRed = 255;
        byte colorGreen = 128;
        byte colorBlue = 0;
        byte transparency = 0;

        return _renderer.material.color = new Color32(colorRed, colorGreen, colorBlue, transparency);
    }

    private void DoDamage()
    {
        int damage = 10;

        _playerController.TakeDamage(damage);
    }

    private void OnCollisionExit()
    {
        _renderer.material.color = _colorStart;
        StopCoroutine(_IEnumerator);
    }
}