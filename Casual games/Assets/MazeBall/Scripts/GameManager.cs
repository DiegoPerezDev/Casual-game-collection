using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace MazeBall
{
    public class GameManager : MonoBehaviour
    {
        public Action OnWinGame, OnLoseGame, OnRestart;
        public event Action OnGameEnds;
        [SerializeField] private Pause pause;
        [SerializeField] private DownTimer timer;
        public bool IsGameEnded { get; private set; }

        void OnEnable()
        {
            OnWinGame  += EndGame;
            OnLoseGame += EndGame;
            OnRestart  += EndGame;
            timer.OnTimerDone += OnLoseGame;
        }
        void OnDisable()
        {
            OnWinGame  -= EndGame;
            OnLoseGame -= EndGame;
            OnRestart  -= EndGame;
            timer.OnTimerDone -= OnLoseGame;
        }

        void Start()
        {
            pause.isActive = true;
        }

        private void EndGame()
        {
            if (IsGameEnded)
                return;
            IsGameEnded = true;

            pause.isActive = false;
            OnGameEnds?.Invoke();
            RestartGameAfterDelay();
        }

        private void RestartGameAfterDelay() => Invoke(nameof(RestartScene), 3f);
        private void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}