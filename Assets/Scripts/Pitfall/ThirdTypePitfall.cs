using System.Collections;
using UnityEngine;

public class ThirdTypePitfall : MonoBehaviour
{
    [SerializeField] Transform _object;

    private float _rotationSpeedPitfall = 2f;

    private IEnumerator _IEnumerator;

    private void FixedUpdate()
    {
        _object.RotateAround(transform.position, transform.up, _rotationSpeedPitfall);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _IEnumerator = DirectionMove(collision);
            StartCoroutine(_IEnumerator);
        }
    }

    private IEnumerator DirectionMove(Collision collision)
    {
        bool isPitfall = true;

        float _rotationSpeed = 1f;

        while (isPitfall)
        {
            yield return null;
            collision.transform.RotateAround(transform.position, transform.up, _rotationSpeed);
        }
    }

    private void OnCollisionExit()
    {
        StopCoroutine(_IEnumerator);
    }
}
