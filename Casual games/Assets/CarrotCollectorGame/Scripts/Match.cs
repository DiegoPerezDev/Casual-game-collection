using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace CarrotCollector
{
    public class Match : MonoBehaviour
    {
        public event Action OnStart;
        [SerializeField] private Pause pause;
        [SerializeField] private DownTimer timer;
        [SerializeField] private PlayerCarrotGathering carrotGathering;
        [SerializeField] private CarrotGenerator carrotGenerator;
        [SerializeField] private GameUI ui;
        [SerializeField] private GameObject losePanel, winPanel;
        [SerializeField] private int maxCarrots = 10;

        private int carrotsGathered;
        private bool gameEnded;
        private const float restartCountdownTimeLimit = 3.2f;

        
        void OnEnable()
        {
            carrotGathering.OnCarrotGather += OnCarrotGather;
            timer.OnTimerDone += LoseGame;
        }
        void OnDisable()
        {
            carrotGathering.OnCarrotGather -= OnCarrotGather;
            timer.OnTimerDone -= LoseGame;
        }


        void Start()
        {
            StartMatch();
        }

        public void StartMatch()
        {
            carrotGenerator.SpawnCarrots(maxCarrots);
            ui.UpdateCarrotsInHud(carrotsGathered, maxCarrots);
            pause.isActive = true;
            OnStart?.Invoke();
        }

        private void OnCarrotGather()
        {
            if (gameEnded)
                return;

            carrotsGathered++;
            ui.UpdateCarrotsInHud(carrotsGathered, maxCarrots);

            if (carrotsGathered >= maxCarrots)
                WinGame();
        }

        // -- -- WIN / LOSE -- --

        private void WinGame()
        {
            winPanel.SetActive(true);
            EndGame();
        }

        private void LoseGame()
        {
            losePanel.SetActive(true);
            EndGame();
        }

        private void EndGame()
        {
            gameEnded = true;
            timer.enabled = false;
            pause.isActive = false;
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