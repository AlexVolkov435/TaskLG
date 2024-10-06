using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AudioSource _clip;

    private int _damage = 20;
    private int _jumpForce = 4;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _clip.Play();
            DoDamage();
            collision.rigidbody.AddForce(new Vector3(2, 2, 0) * _jumpForce, ForceMode.Impulse);
        }
    }
        
    private void DoDamage()
    {
        _playerController.TakeDamage(_damage);
    }
}
