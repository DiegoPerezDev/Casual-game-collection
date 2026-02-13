using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BalloonPopper
{
    public class Match : MonoBehaviour
    {
        public Action OnStart;
        [HideInInspector] public int score;
        [SerializeField] private BalloonsController balloonsController;
        [SerializeField] private Pause pause;
        [SerializeField] private TextMeshProUGUI scoreTMP;
        private bool gameLost;

        private void OnEnable()
        {
            balloonsController.OnBalloonPop += IncreaseScore;
            balloonsController.OnBalloonOut += GameLost;
            pause.OnPause += StopBalloons;
            pause.OnUnpause += ActivateBalloons;
            OnStart += StartMatch;
        }
        private void OnDisable()
        {
            balloonsController.OnBalloonPop -= IncreaseScore;
            balloonsController.OnBalloonOut -= GameLost;
            pause.OnPause -= StopBalloons;
            pause.OnUnpause -= ActivateBalloons;
            OnStart -= StartMatch;
        }

        private void StartMatch()
        {
            pause.EnableMinimizeOnPause();
            ActivateBalloons();
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
            scoreTMP.text = score.ToString();
        }

        private void ActivateBalloons() => balloonsController.ActivateBalloons();
        
        private void StopBalloons() => balloonsController.StopBalloons();

    }
}