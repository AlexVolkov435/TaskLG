using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceStartGame;
    [SerializeField] private AudioSource _audioSourceExitGame;

    public void StartGame()
    {
        _audioSourceStartGame.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        _audioSourceExitGame.Play();
        Application.Quit();
    }
}
