using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private GameObject losePanel;
        [SerializeField] private Timer timer;
        [SerializeField] private Pause pause;
        [SerializeField] private GameUI gameUI;
        private bool gameLost;
        private const float restartCountdownTimeLimit = 4f;


        void OnEnable()
        {
            gameLost = false;
            OnLoseGame += GameLost;
        }
        void OnDisable()
        {
            OnLoseGame -= GameLost;
        }
        void Start()
        {
            gameUI.DisableHUD();
        }


        public void StartLevel()
        {
            stoneSpawner.StartCoroutine(stoneSpawner.Cor_SpawnStone());
            timer.StartTimer();
        }

        private void GameLost()
        {
            if (gameLost)
                return;

            gameLost = true;
            timer.StopTimer();
            gameUI.DisableHUD();
            losePanel.SetActive(true);
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
            RestartGameScene();
        }

        private void RestartGameScene()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}