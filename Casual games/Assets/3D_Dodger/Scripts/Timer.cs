using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ThreeD_Dodger
{
    public class Timer : MonoBehaviour
    {
        public Action OnTimerDone;
        [SerializeField] private TextMeshProUGUI HudTimer;
        [SerializeField] private GameLose gameLose;
        private float counter = 0;
        private bool inSceneBoot = true;


        void OnEnable()
        {
            if (inSceneBoot)
            {
                inSceneBoot = false;
                enabled = false;
            }
            ResetTime();
        }

        void Update()
        {
            UpdateTime();
            UpdateTimerUI();
        }

        public void StopTimer() => enabled = false;
        private void UpdateTime() => counter += Time.deltaTime;
        private void UpdateTimerUI() => HudTimer.text = $"{(int)counter:D2}";
        private void ResetTime() => counter = 0;

    }
}