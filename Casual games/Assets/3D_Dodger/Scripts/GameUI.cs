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
        [SerializeField] private GameLose gameLose;
        [SerializeField] private StoneSpawner stoneSpawner;
        [SerializeField] private GameObject mainMenu, Hud, joystick;

        public void ButtonStartGame()
        {
            Hud.SetActive(true);
            joystick.SetActive(true);
            gameLose.StartMatch();
            mainMenu.SetActive(false);
            stoneSpawner.StartCoroutine(stoneSpawner.Cor_SpawnStone());
        }

        public void ButtonHUDPause() => pause.PauseMatch();

        public void ButtonResumeGame() => pause.UnPauseMatch();

        public void ButtonRestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void ButtonGameSelection() => SceneManager.LoadScene(0);

    }
}