using UnityEngine;

public class TriggerExitZone : MonoBehaviour
{
    [SerializeField] private AudioSource _clip;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _clip.Stop();
        }
    }
}
