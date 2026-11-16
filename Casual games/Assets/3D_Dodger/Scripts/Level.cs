using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThreeD_Dodger
{
    public class Level : MonoBehaviour
    {
        // Start
        [SerializeField] private StoneSpawner stoneSpawner;

        // Lose
        public Action OnLoseGame;
        [SerializeField] private GameObject losePanel, joystick, Hud;
        [SerializeField] private UpTimer timer;
        [SerializeField] private Pause pause;
        [SerializeField] private SharedUIController ui;
        private bool gameLost;
        private const float restartCountdownTimeLimit = 4f;


        void OnEnable()
        {
            ui.OnStartButtonClicked += StartLevel;
            OnLoseGame += GameLost;
            pause.OnPause += DisableJoystick;
            pause.OnUnpause += EnableJoystick;
        }
        void OnDisable()
        {
            ui.OnStartButtonClicked -= StartLevel;
            OnLoseGame -= GameLost;
            pause.OnPause -= DisableJoystick;
            pause.OnUnpause -= EnableJoystick;
        }

        // -- -- ON START -- --


        private void StartLevel()
        {
            timer.StartTimer();
            pause.isActive = true;
            Hud.SetActive(true);
            joystick.SetActive(true);
            stoneSpawner.StartSpawning();
        }

        // -- -- ON LOSE -- --

        private void GameLost()
        {
            if (gameLost)
                return;

            gameLost = true;
            pause.isActive = false;
            timer.Stop();
            Hud.SetActive(false);
            losePanel.SetActive(true);
            StartCoroutine(CorRestartCountdown());
        }

        // -- -- ON PAUSE -- -- 
        private void EnableJoystick() => joystick.SetActive(true);
        private void DisableJoystick() => joystick.SetActive(false);


        // -- -- ON RESTART -- -- 

        private IEnumerator CorRestartCountdown()
        {
            float counting = 0;
            while (counting <= restartCountdownTimeLimit)
            {
                yield return null;
                counting += Time.deltaTime;
            }
            RestartGameScene();
        }

        private void RestartGameScene() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}