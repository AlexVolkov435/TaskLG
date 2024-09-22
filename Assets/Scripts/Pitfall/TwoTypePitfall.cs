using System.Collections;
using UnityEngine;

public class TwoTypePitfall : MonoBehaviour
{
    private IEnumerator _IEnumerator;

    private int _time = 0;

    private void Start()
    {
        StartCoroutine(CountTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _IEnumerator = DirectionMove(collision);
            StartCoroutine(_IEnumerator);
        }
    }

    private void OnCollisionExit()
    {
        StopCoroutine(_IEnumerator);
    }

    private IEnumerator DirectionMove(Collision collision)
    {
        bool isPitfall = true;

        int directionRight = 1;
        int directionLeft = -1;

        while (isPitfall)
        {
            yield return null;

            if (_time % 2 == 0)
            {
                collision.rigidbody.velocity = new Vector3(directionRight, 0, 0);
            }
            else
            {
                collision.rigidbody.velocity = new Vector3(directionLeft, 0, 0);
            }
        }
    }

    private IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            _time++;
        }
    }
}

