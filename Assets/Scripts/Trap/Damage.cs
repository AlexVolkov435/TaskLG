using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private int _damage = 20;
    [SerializeField] private AudioSource _clip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _clip.Play();
            DoDamage();
        }
    }

    private void DoDamage()
    {
        _playerController.TakeDamage(_damage);
    }
}
