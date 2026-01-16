using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CarrotCollector
{
    public class Timer : MonoBehaviour
    {
        public Action OnTimerDone;
        [HideInInspector] public bool stopped;
        [SerializeField] private TextMeshProUGUI HudTimer;
        private const string timerConstText = "Time left: ";
        private const float countdownTimeLimit = 10f; //50
        private float countdownTimeLeft = countdownTimeLimit;
        

        void Start()
        {
            UpdateTimerUI();
        }

        void Update()
        {
            if (stopped)
                return;

            UpdateTime();
            UpdateTimerUI();
            if (IsTimerDone())
            {
                OnTimerDone();
                ResetTime();
                stopped = true;
            }
        }

        private void UpdateTime() => countdownTimeLeft -= Time.deltaTime;

        private void UpdateTimerUI() => HudTimer.text = $"{timerConstText}{(int)countdownTimeLeft}";

        private bool IsTimerDone() => countdownTimeLeft <= 0;

        private void ResetTime() => countdownTimeLeft = countdownTimeLimit;

    }
}