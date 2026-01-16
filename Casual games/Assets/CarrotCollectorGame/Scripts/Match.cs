using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CarrotCollector
{
    public class Match : MonoBehaviour
    {
        // Lose
        [SerializeField] private GameObject losePanel;
        [SerializeField] private Timer timer;

        // Win
        [SerializeField] private CarrotGenerator carrotGenerator;
        [SerializeField] private GameObject winPanel;
        [HideInInspector] public int carrotsMaxAmount;
        private int carrotsGathered = 0;

        // Gameflow in general
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Pause pause;
        [SerializeField] private PlayerCarrotGathering carrotGathering;
        private const float restartCountdownTimeLimit = 3.2f;

        

        void OnEnable()
        {
            carrotGathering.OnCarrotGather += OnCarrotGather;
            timer.OnTimerDone += GameLost;
            pause.OnPause += Pause;
            pause.OnUnpause += Unpause;
        }
        void OnDisable()
        {
            carrotGathering.OnCarrotGather -= OnCarrotGather;
            timer.OnTimerDone -= GameLost;
            pause.OnPause -= Pause;
            pause.OnUnpause -= Unpause;
        }

        private void Awake()
        {
            GetCarrotMaxAmount();
        }
        void Start()
        {
            StartGame();
        }


        // -- -- Start -- --

        private void StartGame()
        {
            // Pause so the player cannot move and the counter won't start until clicking the start button.
            pause.PauseMatch();
        }

        public void StartMatch()
        {
            carrotGenerator.SpawnCarrots();
            pause.UnPauseMatch();
        }

        // -- -- Pausing -- -- 

        private void Pause()
        {
            timer.stopped = true;
            pauseMenu.SetActive(true);
        }
        private void Unpause()
        {
            timer.stopped = false;
            pauseMenu.SetActive(false);
        }

        // -- -- WIN -- -- 

        private void GetCarrotMaxAmount() => carrotsMaxAmount = carrotGenerator ? carrotGenerator.carrotsAmount : 0;

        private void OnCarrotGather()
        {
            carrotsGathered++;

            if (carrotsGathered >= carrotsMaxAmount)
                WinGame();
        }

        private void WinGame()
        {
            if (winPanel)
                winPanel.SetActive(true);
            timer.enabled = false;
            StartCoroutine(CorRestartCountdown());
        }


        // -- -- LOSE -- --

        private void GameLost()
        {
            if (losePanel)
                losePanel.SetActive(true);
            timer.enabled = false;
            carrotGathering.disabled = true;
            StartCoroutine(CorRestartCountdown());
        }


        // -- -- RESTART -- -- 

        private IEnumerator CorRestartCountdown()
        {
            float counting = 0;
            while (counting <= restartCountdownTimeLimit)
            {
                yield return null;
                counting += Time.deltaTime;
            }
            RestartGame();
        }

        private void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}