using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonPopper
{
    public class UI_PanelsManagement : MonoBehaviour
    {
        [SerializeField] private Match match;
        [SerializeField] private Pause pause;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject mainMenu, Hud;

        private void OnEnable()
        {
            pause.OnPause   += EnablePauseMenu;
            pause.OnUnpause += DisablePauseMenu;
            match.OnStart   += StartGame;
        }
        private void OnDisable()
        {
            pause.OnPause   -= EnablePauseMenu;
            pause.OnUnpause -= DisablePauseMenu;
            match.OnStart   -= StartGame;
        }

        private void StartGame()
        {
            Hud.SetActive(true);
            mainMenu.SetActive(false);
        }
        private void EnablePauseMenu() => pauseMenu.SetActive(true);
        private void DisablePauseMenu() => pauseMenu.SetActive(false);

    }
}