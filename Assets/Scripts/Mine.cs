using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private int _damage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        DoDamage();
    }

    private void DoDamage()
    {
        _playerController.TakeDamage(_damage);
    }
}
