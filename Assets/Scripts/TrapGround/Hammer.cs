using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private int _damage = 20;

    private int _jumpForce = 4;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            DoDamage();
            collision.rigidbody.AddForce(new Vector3(2, 2, 0) * _jumpForce, ForceMode.Impulse);
        }
    }
        
    private void DoDamage()
    {
        _playerController.TakeDamage(_damage);
    }
}
