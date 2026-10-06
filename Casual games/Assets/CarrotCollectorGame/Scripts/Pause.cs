using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CarrotCollector
{
    public class Pause : MonoBehaviour
    {
        public Action OnPause, OnUnpause;
        [SerializeField] private GameObject pauseMenu;
        private bool paused = false;
        private bool minimizeOnPause = false;

        void OnEnable()
        {
            OnPause += Paused;
            OnUnpause += UnPaused;
        }
        void OnDisable()
        {
            OnPause -= Paused;
            OnUnpause -= UnPaused;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnPause?.Invoke();
        }

        public void PauseOrUnpause()
        {
            if (!paused)
                OnPause?.Invoke();
            else
                OnUnpause?.Invoke();
        }

        public void Paused()
        {
            if (paused)
                return;
            Time.timeScale = 0f;
            paused = true;
            pauseMenu.SetActive(true);
        }

        public void UnPaused()
        {
            if (!paused)
                return;
            Time.timeScale = 1.0f;
            paused = false;
            pauseMenu.SetActive(false);
        }

        // Pause is not looking at the screen while unpaused
        private void OnApplicationFocus(bool focus)
        {
            if (!minimizeOnPause)
                return;
            if (!focus && !paused)
                OnPause?.Invoke();
        }

        public void EnableMinimizeOnPause() => minimizeOnPause = true;
    }
}