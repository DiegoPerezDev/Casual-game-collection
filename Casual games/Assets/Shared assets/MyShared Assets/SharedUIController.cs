using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SharedUIController : MonoBehaviour
{
    public event Action OnStartButtonClicked;
    [SerializeField] private Pause pause;
    [SerializeField] private GameObject mainMenu;

    public void ButtonStartGame()
    {
        OnStartButtonClicked?.Invoke();
        if(mainMenu != null)
            mainMenu.SetActive(false);
    }
    public void ButtonHUDPause() => pause.PauseGame();
    public void ButtonResumeGame() => pause.UnpauseGame();
    public void ButtonRestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void ButtonGameSelection() => SceneManager.LoadScene(0);
        
}