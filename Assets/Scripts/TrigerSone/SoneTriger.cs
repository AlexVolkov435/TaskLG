using UnityEngine;
using UnityEngine.UIElements;

public class SoneTriger : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    [SerializeField] Animator _animator;
    [SerializeField] Animator _animator2;

    private void Start()
    {
        _gameObject.SetActive(false);
        _animator.GetComponent<Animator>();
        _animator2.GetComponent<Animator>().SetBool("isStart", true); ;
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameObject.SetActive(true);
        _animator.SetBool("isStart", true);
    }
}
