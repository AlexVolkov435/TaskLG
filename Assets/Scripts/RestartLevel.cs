using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField]  private GameObject _defeat;
    public static RestartLevel Restart;

    private void Start()
    {
        _defeat.SetActive(false);
        Restart = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out var pitfall))
        {
            _defeat.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }
}
