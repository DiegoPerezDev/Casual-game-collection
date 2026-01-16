using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeD_Dodger
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        private bool paused = true;

        void Start()
        {
            Time.timeScale = 0f;
        }

        public void PauseMatch()
        {
            if (paused)
                return;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
        }

        public void UnPauseMatch()
        {
            if (!paused)
                return;
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            paused = false;
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!focus && !paused)
                PauseMatch();
        }

    }
}