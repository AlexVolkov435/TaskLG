using System.Collections;
using UnityEngine;

public class FifthTypePitfall : MonoBehaviour
{
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    [SerializeField] private float _pause;

    private IEnumerator _IEnumerator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _IEnumerator = Counter();
            StartCoroutine(_IEnumerator);
        }
    }

    private IEnumerator Counter()
    {
        var wait = new WaitForSeconds(_pause);

        _renderer.material.color = Color.red;

        yield return wait;

        _rigidbody.isKinematic = false;
    }
}
