using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CarrotCollector
{
    public class Pause : MonoBehaviour
    {
        public Action OnPause, OnUnpause;
        private bool paused = false;

        public void PauseMatch()
        {
            if (paused)
                return;
            Time.timeScale = 0f;
            paused = true;
            OnPause();
        }

        public void UnPauseMatch()
        {
            if (!paused)
                return;
            Time.timeScale = 1.0f;
            paused = false;
            OnUnpause();
        }

        // Pause is not looking at the screen while unpaused
        private void OnApplicationFocus(bool focus)
        {
            if (!focus && !paused)
                PauseMatch();
        }
    }
}