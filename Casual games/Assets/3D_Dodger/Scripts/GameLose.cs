using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThreeD_Dodger
{
    public class GameLose : MonoBehaviour
    {
        // Lose
        public Action OnLoseGame;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private Timer timer;
        [SerializeField] private PlayerMovement playerMovement;
        private bool gameLost = false;

        // Both
        [SerializeField] private Pause pause;
        private const float restartCountdownTimeLimit = 4f;


        void OnEnable()
        {
            OnLoseGame += GameLost;
            OnLoseGame += timer.StopTimer;
        }
        void OnDisable()
        {
            OnLoseGame -= GameLost;
            OnLoseGame -= timer.StopTimer;
        }

        // -- -- StartMatch -- --

        public void StartMatch()
        {
            pause.UnPauseMatch();
            timer.enabled = true;
        }


        // -- -- LOSE -- --

        private void GameLost()
        {
            if (gameLost)
                return;

            playerMovement.enabled = false;
            if (losePanel)
                losePanel.SetActive(true);
            StartCoroutine(CorRestartCountdown());
            gameLost = true;
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

        private void RestartGameScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}