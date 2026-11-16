using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BalloonPopper
{
    public class Match : MonoBehaviour
    {
        public static Match Instance { get; private set; }
        public event Action OnStart;
        public BalloonsController balloonsController;

        [SerializeField] private UI ui;
        [SerializeField] private Pause pause;
        [SerializeField] private SharedUIController uiController;
        private int score;
        private bool gameLost;


        void OnEnable()
        {
            balloonsController.OnBalloonPop   += IncreaseScore;
            balloonsController.OnBalloonOut   += GameLost;
            uiController.OnStartButtonClicked += StartMatch;
            pause.OnPause   += StopBalloons;
            pause.OnUnpause += ActivateBalloons;
        }
        void OnDisable()
        {
            balloonsController.OnBalloonPop   -= IncreaseScore;
            balloonsController.OnBalloonOut   -= GameLost;
            uiController.OnStartButtonClicked -= StartMatch;
            pause.OnPause   -= StopBalloons;
            pause.OnUnpause -= ActivateBalloons;
        }

        void Awake()
        {
            Instance = this;
        }

        private void StartMatch()
        {
            pause.isActive = true;
            ActivateBalloons();
            OnStart?.Invoke();
        }

        private void GameLost()
        {
            if (gameLost)
                return;

            gameLost = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void IncreaseScore()
        {
            score++;
            ui.IncreaseScore(score);
            CheckSpeedInc();
        }

        private void CheckSpeedInc()
        {
            if (score != 0 && (score % 8 == 0))
                balloonsController.IncreaseSpeed();
        }

        private void ActivateBalloons() => balloonsController.ActivateBalloons();
        private void StopBalloons()     => balloonsController.StopBalloons();

    }
}