using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CarrotCollector
{
    // Pause menu, HUD and Main menu
    public class UI_Buttons : MonoBehaviour
    {
        [SerializeField] private Pause pause;
        [SerializeField] private Match match;
        [SerializeField] private GameObject mainMenu, Hud, joystick;

        public void ButtonStartGame()
        {
            Hud.SetActive(true);
            joystick.SetActive(true);
            mainMenu.SetActive(false);
            match.StartMatch();
        }

        public void ButtonHUDPause() => pause.PauseMatch();

        public void ButtonResumeGame() => pause.UnPauseMatch();

        public void ButtonRestartGame()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ButtonGameSelection()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        }

    }
}