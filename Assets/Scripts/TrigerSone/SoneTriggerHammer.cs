using UnityEngine;

public class SoneTriggerHammer : MonoBehaviour
{
    [SerializeField] GameObject _hammer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animator2;

    private void Start()
    {
        _hammer.SetActive(false);
        _animator.GetComponent<Animator>();
        _animator2.GetComponent<Animator>().SetBool("isStart", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        _hammer.SetActive(true);
        _animator.SetBool("isStart", true);
    }
}
