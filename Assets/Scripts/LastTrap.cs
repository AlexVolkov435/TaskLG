using UnityEngine;

public class LastTrap : MonoBehaviour
{
    [SerializeField] private GameObject _trap;
    [SerializeField] private Rigidbody _trapPosition;
    [SerializeField] private AudioSource _clip;

    private float _jumpForce = 2;

    private void Start()
    {
        _trap.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _clip.Play();
            _trap.SetActive(true);

            _trapPosition.isKinematic = false;
            _trapPosition.AddForce(new Vector3(0, 0, -2) * _jumpForce, ForceMode.Impulse);
        }
    }
}