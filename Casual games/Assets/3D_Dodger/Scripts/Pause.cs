using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeD_Dodger
{
    public class Pause : MonoBehaviour
    {
        public Action OnPause, OnUnpause;
        [SerializeField] private Level level;
        private bool paused, active = true;

        private void OnEnable()
        {
            active = true;
            OnPause += PauseMatch;
            OnUnpause += UnPauseMatch;
            level.OnLoseGame += DisablePausing;
        } 
        private void OnDisable()
        {
            OnPause -= PauseMatch;
            OnUnpause -= UnPauseMatch;
            level.OnLoseGame -= DisablePausing;
        }

        private void PauseMatch()
        {
            if (paused || !active)
                return;
            Time.timeScale = 0f;
            paused = true;
        }

        private void UnPauseMatch()
        {
            if (!paused)
                return;
            Time.timeScale = 1.0f;
            paused = false;
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!active)
                return;

            if (!focus && !paused)
                OnPause?.Invoke();
        }

        private void DisablePausing()
        {
            active = false;
            OnPause = null;
        }
    }
}