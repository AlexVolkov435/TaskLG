using UnityEngine;

public class TriggerEntryZone : MonoBehaviour
{
    [SerializeField] private AudioSource _clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _clip.Play();
        }
    }
}
