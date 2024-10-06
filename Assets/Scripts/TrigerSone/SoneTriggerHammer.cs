using UnityEngine;

public class SoneTriggerHammer : MonoBehaviour
{
    [SerializeField] GameObject _hammer;
    [SerializeField] private AudioSource _clip;
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
        if (other.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _clip.Play();
            _hammer.SetActive(true);
            _animator.SetBool("isStart", true);
        }
    }
}
