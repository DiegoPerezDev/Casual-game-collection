using CarrotCollector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThreeD_Dodger
{
    // pause menu, HUD and Main menu
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Pause pause;
        [SerializeField] private Level level;
        [SerializeField] private GameObject mainMenu, Hud, joystick, pauseMenu;

        private void OnEnable()
        {
            pause.OnPause += EnablePauseMenu;
            pause.OnUnpause += DisablePauseMatch;
        }
        private void OnDisable()
        {
            pause.OnPause -= EnablePauseMenu;
            pause.OnUnpause -= DisablePauseMatch;
        }

        public void ButtonStartGame()
        {
            Hud.SetActive(true);
            joystick.SetActive(true);
            mainMenu.SetActive(false);
            level.StartLevel();
        }

        // BUTTONS
        public void ButtonHUDPause() => pause.OnPause?.Invoke();

        public void ButtonResumeGame() => pause.OnUnpause?.Invoke();

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


        // OTHERS
        private void EnablePauseMenu() => pauseMenu.SetActive(true);

        private void DisablePauseMatch() => pauseMenu.SetActive(false);

        public void DisableHUD()
        {
            Hud.SetActive(false);
        }
    }
}