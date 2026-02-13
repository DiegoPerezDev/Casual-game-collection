using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BalloonPopper
{
    public class Pause : MonoBehaviour
    {
        public Action OnPause, OnUnpause;
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

        private void Paused() => paused = true;

        private void UnPaused() => paused = false;

        // Pause is not looking at the screen while unpaused
        private void OnApplicationFocus(bool focus)
        {
            if(!minimizeOnPause)
                return;
            if (!focus && !paused)
                OnPause?.Invoke();
        }

        public void EnableMinimizeOnPause() => minimizeOnPause = true;
    }
}