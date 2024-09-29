using UnityEngine;

public class Thorns : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private int _damage = 10;
    private int _jumpForce = 3;

    private void OnCollisionEnter(Collision collision)
    {
        DoDamage();
        collision.rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void DoDamage()
    {
        _playerController.TakeDamage(_damage);
    }
}
