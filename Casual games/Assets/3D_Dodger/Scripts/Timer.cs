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
        private float counter = 0;
        private bool active;


        void Update()
        {
            if (!active)
                return;
            UpdateTime();
            UpdateTimerUI();
        }

        public void StartTimer()
        {
            ResetTime();
            HudTimer.gameObject.SetActive(true);
            active = true;
        }
        public void DisableTimer()
        {
            HudTimer.gameObject.SetActive(false);
            StopTimer();
        }

        public void StopTimer() => active = false;
        private void UpdateTime() => counter += Time.deltaTime;
        private void UpdateTimerUI() => HudTimer.text = $"{(int)counter:D2}";
        private void ResetTime() => counter = 0;

    }
}