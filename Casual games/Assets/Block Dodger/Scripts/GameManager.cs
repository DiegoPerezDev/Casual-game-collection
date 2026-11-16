using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockDodger
{
    public class GameManager : MonoBehaviour
    {
        public Action OnGameStart, OnGameEnd;
        public Action OnScoreUp;
        [SerializeField] private BlockSpawner blockSpawner;
        [SerializeField] private Pause pause;
        private bool gameStarted;
        private int score;
        

        void OnEnable()
        {
            OnScoreUp   += ScoreUp;
            OnGameStart += ActivatePauseSystem;
            OnGameEnd   += RestartScene;
        }
        void OnDisable()
        {
            OnScoreUp   -= ScoreUp;
            OnGameStart -= ActivatePauseSystem;
            OnGameEnd   -= RestartScene;
        }

        void Update()
        {
            StartGameOnClick();
        }


        private void StartGameOnClick()
        {
            if (gameStarted)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                OnGameStart?.Invoke();
                gameStarted = true;
            }
        }

        private void ScoreUp()
        {
            score++;
            CheckForSpeedUp();
        }

        private void CheckForSpeedUp()
        {
            if (score != 0 && score % 8 == 0)
            {
                foreach (var block in blockSpawner.Blocks)
                    blockSpawner.IncreaseBlocksSpeed();
            }
        }

        private void ActivatePauseSystem() => pause.isActive = true;
        private void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}